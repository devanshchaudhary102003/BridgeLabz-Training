using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

// ===================== ATTRIBUTES =====================

[AttributeUsage(AttributeTargets.Method)]
public class PublicAPIAttribute : Attribute
{
    public string Description { get; private set; }
    public PublicAPIAttribute(string description)
    {
        Description = description;
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class RequiresAuthAttribute : Attribute
{
    public string Role { get; private set; }
    public RequiresAuthAttribute(string role)
    {
        Role = role;
    }
}

// Simple HTTP method attributes (to simulate REST endpoints)
[AttributeUsage(AttributeTargets.Method)]
public class HttpGetAttribute : Attribute
{
    public string Route { get; private set; }
    public HttpGetAttribute(string route)
    {
        Route = route;
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class HttpPostAttribute : Attribute
{
    public string Route { get; private set; }
    public HttpPostAttribute(string route)
    {
        Route = route;
    }
}

// Documentation metadata
[AttributeUsage(AttributeTargets.Method)]
public class ApiDocAttribute : Attribute
{
    public string Summary { get; private set; }
    public string ResponseExample { get; private set; }

    public ApiDocAttribute(string summary, string responseExample)
    {
        Summary = summary;
        ResponseExample = responseExample;
    }
}

// ===================== SAMPLE CONTROLLERS =====================

public class LabTestsController
{
    [PublicAPI("Anyone can view available tests")]
    [HttpGet("/api/labs/tests")]
    [ApiDoc("List all available lab tests", "[\"CBC\",\"LFT\",\"KFT\"]")]
    public string GetAllTests()
    {
        return "CBC, LFT, KFT";
    }

    [PublicAPI("Book a lab test")]
    [RequiresAuth("PATIENT")]
    [HttpPost("/api/labs/book")]
    [ApiDoc("Book a lab test for patient", "{\"status\":\"booked\"}")]
    public string BookTest(string testName)
    {
        return "Booked: " + testName;
    }

    // Intentionally missing attributes for validator demo
    public string InternalHelper()
    {
        return "helper";
    }
}

public class ReportsController
{
    [PublicAPI("Get report by reportId")]
    [RequiresAuth("DOCTOR")]
    [HttpGet("/api/reports/{id}")]
    [ApiDoc("Fetch a lab report by id", "{\"id\":101,\"result\":\"Normal\"}")]
    public string GetReportById(int id)
    {
        return "Report " + id;
    }

    // Missing ApiDoc intentionally
    [PublicAPI("Download report PDF")]
    [RequiresAuth("PATIENT")]
    [HttpGet("/api/reports/{id}/download")]
    public string DownloadReport(int id)
    {
        return "PDF bytes...";
    }
}

// ===================== HEALTHCHECKPRO SCANNER =====================

public class ApiIssue
{
    public string ControllerName;
    public string MethodName;
    public string Problem;
}

public class ApiEndpointDoc
{
    public string ControllerName;
    public string MethodName;
    public string HttpMethod;
    public string Route;
    public string PublicDescription;
    public string AuthRole;
    public string Summary;
    public string ResponseExample;
}

public static class HealthCheckPro
{
    public static void RunScan(Assembly assembly)
    {
        List<ApiIssue> issues = new List<ApiIssue>();
        List<ApiEndpointDoc> docs = new List<ApiEndpointDoc>();

        // "Controller" classes: simple naming rule for demo
        Type[] controllers = assembly.GetTypes()
            .Where(t => t.IsClass && t.Name.EndsWith("Controller"))
            .ToArray();

        foreach (Type controller in controllers)
        {
            MethodInfo[] methods = controller.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            foreach (MethodInfo method in methods)
            {
                // Ignore property getters/setters or special methods
                if (method.IsSpecialName) continue;

                PublicAPIAttribute publicAttr = GetAttr<PublicAPIAttribute>(method);
                RequiresAuthAttribute authAttr = GetAttr<RequiresAuthAttribute>(method);
                HttpGetAttribute getAttr = GetAttr<HttpGetAttribute>(method);
                HttpPostAttribute postAttr = GetAttr<HttpPostAttribute>(method);
                ApiDocAttribute docAttr = GetAttr<ApiDocAttribute>(method);

                bool hasHttp = (getAttr != null) || (postAttr != null);
                bool isPublic = (publicAttr != null);

                // If it's not public API, skip doc generation but still flag if it has partial API attributes
                if (!isPublic)
                {
                    // if it has http route but not public marker -> issue
                    if (hasHttp)
                    {
                        issues.Add(new ApiIssue
                        {
                            ControllerName = controller.Name,
                            MethodName = method.Name,
                            Problem = "Has HTTP route but missing [PublicAPI]"
                        });
                    }
                    continue;
                }

                // Validate required annotations
                if (!hasHttp)
                {
                    issues.Add(new ApiIssue
                    {
                        ControllerName = controller.Name,
                        MethodName = method.Name,
                        Problem = "Missing HTTP method attribute ([HttpGet] or [HttpPost])"
                    });
                }

                // Public endpoints should explicitly specify auth state:
                // Either [RequiresAuth] or clearly say "No auth" by leaving it blank (we'll warn)
                if (authAttr == null)
                {
                    issues.Add(new ApiIssue
                    {
                        ControllerName = controller.Name,
                        MethodName = method.Name,
                        Problem = "Public API missing [RequiresAuth] (is it open or protected?)"
                    });
                }

                if (docAttr == null)
                {
                    issues.Add(new ApiIssue
                    {
                        ControllerName = controller.Name,
                        MethodName = method.Name,
                        Problem = "Missing [ApiDoc] documentation"
                    });
                }

                // Build documentation entry even if some are missing
                string httpMethod = getAttr != null ? "GET" : (postAttr != null ? "POST" : "UNKNOWN");
                string route = getAttr != null ? getAttr.Route : (postAttr != null ? postAttr.Route : "N/A");

                ApiEndpointDoc endpoint = new ApiEndpointDoc();
                endpoint.ControllerName = controller.Name;
                endpoint.MethodName = method.Name;
                endpoint.HttpMethod = httpMethod;
                endpoint.Route = route;
                endpoint.PublicDescription = publicAttr.Description;
                endpoint.AuthRole = authAttr != null ? authAttr.Role : "NOT SPECIFIED";
                endpoint.Summary = docAttr != null ? docAttr.Summary : "NO SUMMARY";
                endpoint.ResponseExample = docAttr != null ? docAttr.ResponseExample : "NO EXAMPLE";

                docs.Add(endpoint);
            }
        }

        PrintIssues(issues);
        PrintDocs(docs);

        // Optional: write docs to a file
        WriteDocsToFile(docs, "HealthCheckPro_API_Docs.md");
    }

    private static T GetAttr<T>(MethodInfo method) where T : Attribute
    {
        object[] attrs = method.GetCustomAttributes(typeof(T), false);
        if (attrs.Length == 0) return null;
        return (T)attrs[0];
    }

    private static void PrintIssues(List<ApiIssue> issues)
    {
        Console.WriteLine("====================================");
        Console.WriteLine("HealthCheckPro - Validation Report");
        Console.WriteLine("====================================");

        if (issues.Count == 0)
        {
            Console.WriteLine("No issues found. All APIs properly annotated.");
            Console.WriteLine();
            return;
        }

        Console.WriteLine("Issues Found: " + issues.Count);
        Console.WriteLine("------------------------------------");

        foreach (ApiIssue i in issues)
        {
            Console.WriteLine("Controller: " + i.ControllerName);
            Console.WriteLine("Method    : " + i.MethodName);
            Console.WriteLine("Problem   : " + i.Problem);
            Console.WriteLine("------------------------------------");
        }

        Console.WriteLine();
    }

    private static void PrintDocs(List<ApiEndpointDoc> docs)
    {
        Console.WriteLine("====================================");
        Console.WriteLine("Auto-Generated API Documentation");
        Console.WriteLine("====================================");

        foreach (ApiEndpointDoc d in docs.OrderBy(x => x.ControllerName).ThenBy(x => x.Route))
        {
            Console.WriteLine(d.HttpMethod + " " + d.Route);
            Console.WriteLine("Controller : " + d.ControllerName);
            Console.WriteLine("Method     : " + d.MethodName);
            Console.WriteLine("Public API : " + d.PublicDescription);
            Console.WriteLine("Auth Role  : " + d.AuthRole);
            Console.WriteLine("Summary    : " + d.Summary);
            Console.WriteLine("Example    : " + d.ResponseExample);
            Console.WriteLine("------------------------------------");
        }

        Console.WriteLine();
    }

    private static void WriteDocsToFile(List<ApiEndpointDoc> docs, string fileName)
    {
        List<string> lines = new List<string>();
        lines.Add("# HealthCheckPro - API Documentation");
        lines.Add("");

        foreach (ApiEndpointDoc d in docs.OrderBy(x => x.ControllerName).ThenBy(x => x.Route))
        {
            lines.Add("## " + d.HttpMethod + " " + d.Route);
            lines.Add("- Controller: " + d.ControllerName);
            lines.Add("- Method: " + d.MethodName);
            lines.Add("- Public API: " + d.PublicDescription);
            lines.Add("- RequiresAuth Role: " + d.AuthRole);
            lines.Add("- Summary: " + d.Summary);
            lines.Add("- Response Example: " + d.ResponseExample);
            lines.Add("");
        }

        File.WriteAllLines(fileName, lines);
        Console.WriteLine("Docs saved to file: " + fileName);
    }
}

// ===================== MAIN =====================

public class APIMetadataValidator
{
    public static void Main(string[] args)
    {
        HealthCheckPro.RunScan(Assembly.GetExecutingAssembly());
    }
}
