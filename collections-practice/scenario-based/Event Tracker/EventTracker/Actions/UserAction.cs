using EventTracker.Attributes;
namespace EventTracker.Actions;

public class UserAction
{
    [AuditTrial("USER_LOGIN")]
    public void Login(string username)
    {
        Console.WriteLine("Login done for: "+username);
    }

    [AuditTrial("FILE_UPLOAD")]
    public void FileUpload(string username, string fileName)
    {
        Console.WriteLine(username+" uploaded file: "+fileName);
    }

    [AuditTrial("FILE_DELETE")]
    public void FileDelete(string username, string fileName)
    {
        Console.WriteLine(username+" Deleted file: "+fileName);
    }

    public void NormalMethod()
    {
        Console.WriteLine("Normal Method Called");
    }
}