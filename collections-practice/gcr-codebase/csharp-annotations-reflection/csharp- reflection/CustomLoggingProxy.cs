using System;
using System.Reflection;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;

// 1) Interface
public interface IGreeting
{
    void SayHello(string name);
}

// 2) Real class
public class GreetingService : MarshalByRefObject, IGreeting
{
    public void SayHello(string name)
    {
        Console.WriteLine("Hello, " + name + "!");
    }
}

// 3) Custom Logging Proxy using RealProxy
public class LoggingProxy<T> : RealProxy where T : class
{
    private readonly T _target;

    public LoggingProxy(T target) : base(typeof(T))
    {
        _target = target;
    }

    public override IMessage Invoke(IMessage msg)
    {
        IMethodCallMessage call = (IMethodCallMessage)msg;
        MethodInfo method = (MethodInfo)call.MethodBase;

        Console.WriteLine("[LOG] Calling: " + method.Name);

        object result = method.Invoke(_target, call.Args);

        return new ReturnMessage(result, null, 0, call.LogicalCallContext, call);
    }
}

// 4) Demo
public class CustomLoggingProxy
{
    public static void Main()
    {
        IGreeting real = new GreetingService();

        LoggingProxy<IGreeting> proxy = new LoggingProxy<IGreeting>(real);
        IGreeting logged = (IGreeting)proxy.GetTransparentProxy();

        logged.SayHello("Devansh");
    }
}
