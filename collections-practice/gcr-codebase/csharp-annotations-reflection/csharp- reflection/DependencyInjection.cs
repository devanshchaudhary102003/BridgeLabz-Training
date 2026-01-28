using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// ===================== 1) [Inject] Attribute =====================
[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Property)]
public class InjectAttribute : Attribute { }

// ===================== 2) Simple Reflection-based DI Container =====================
public class SimpleContainer
{
    private readonly Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();
    private readonly Dictionary<Type, object> _singletons = new Dictionary<Type, object>();

    public void Register<TService, TImpl>() where TImpl : TService
    {
        _registrations[typeof(TService)] = typeof(TImpl);
    }

    public void Register<T>()
    {
        _registrations[typeof(T)] = typeof(T);
    }

    public void ScanAndRegister(Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract);

        foreach (var t in types)
        {
            if (!_registrations.ContainsKey(t))
                _registrations[t] = t;
        }
    }

    public T Resolve<T>()
    {
        return (T)Resolve(typeof(T));
    }

    public object Resolve(Type serviceType)
    {
        if (_singletons.ContainsKey(serviceType))
            return _singletons[serviceType];

        Type implType = GetImplementationType(serviceType);

        ConstructorInfo ctor = SelectConstructor(implType);

        object[] args = ctor.GetParameters()
            .Select(p => Resolve(p.ParameterType))
            .ToArray();

        object instance = ctor.Invoke(args);

        InjectFields(instance, implType);
        InjectProperties(instance, implType);

        _singletons[serviceType] = instance;
        return instance;
    }

    private Type GetImplementationType(Type serviceType)
    {
        if (_registrations.ContainsKey(serviceType))
            return _registrations[serviceType];

        if (serviceType.IsClass && !serviceType.IsAbstract)
            return serviceType;

        throw new InvalidOperationException("No registration for: " + serviceType.FullName);
    }

    private static ConstructorInfo SelectConstructor(Type implType)
    {
        ConstructorInfo[] ctors = implType.GetConstructors();

        ConstructorInfo injectCtor = ctors.FirstOrDefault(c => c.GetCustomAttribute<InjectAttribute>() != null);
        if (injectCtor != null) return injectCtor;

        ConstructorInfo best = ctors
            .OrderByDescending(c => c.GetParameters().Length)
            .FirstOrDefault();

        if (best == null)
            throw new InvalidOperationException("No public constructor found for " + implType.FullName);

        return best;
    }

    private void InjectFields(object instance, Type implType)
    {
        var fields = implType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(f => f.GetCustomAttribute<InjectAttribute>() != null);

        foreach (var f in fields)
        {
            object dep = Resolve(f.FieldType);
            f.SetValue(instance, dep);
        }
    }

    private void InjectProperties(object instance, Type implType)
    {
        var props = implType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(p => p.GetCustomAttribute<InjectAttribute>() != null && p.CanWrite);

        foreach (var p in props)
        {
            object dep = Resolve(p.PropertyType);
            p.SetValue(instance, dep, null);
        }
    }
}

// ===================== 3) Example Services =====================
public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine("LOG: " + message);
    }
}

public class Repository
{
    private readonly ILogger _logger;

    [Inject]
    public Repository(ILogger logger)
    {
        _logger = logger;
    }

    public void Save()
    {
        _logger.Log("Data saved!");
    }
}

// ✅ FIXED: Constructor Injection (No CS0649 warning)
public class Service
{
    private readonly Repository _repo;
    private readonly ILogger _logger;

    [Inject]
    public Service(Repository repo, ILogger logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public void DoWork()
    {
        _logger.Log("Service started");
        _repo.Save();
        _logger.Log("Service finished");
    }
}

// ===================== 4) Main =====================
class DependencyInjection
{
    static void Main(string[] args)
    {
        SimpleContainer container = new SimpleContainer();

        container.Register<ILogger, ConsoleLogger>();

        // auto-register all concrete types in this assembly
        container.ScanAndRegister(Assembly.GetExecutingAssembly());

        Service service = container.Resolve<Service>();
        service.DoWork();

        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}
