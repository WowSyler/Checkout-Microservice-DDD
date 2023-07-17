namespace Checkout.Application.Exceptions;

public class Exceptions
{
    public static void SetGlobalExceptionHandler()
    {
        AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
    }

    static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
    {
        System.Console.WriteLine(e.ExceptionObject.ToString());
        System.Console.WriteLine("Press Enter to Exit");
        System.Console.ReadLine();
        Environment.Exit(0);
    }
}