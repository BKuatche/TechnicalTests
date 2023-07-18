using OhceApp.Services;

public class Program
{
    static void Main(string[] args)
    {
        string userName = args[0];
        string stopContent = "Stop!";
        int hour = DateTime.Now.Hour;

        var ohce = new OhceService(stopContent, hour);
        ohce.RunApp(userName);
    }
}
