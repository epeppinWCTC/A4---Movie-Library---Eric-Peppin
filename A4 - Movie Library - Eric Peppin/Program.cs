using System;
using A4___Movie_Library___Eric_Peppin;
using A4___Movie_Library___Eric_Peppin.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var startup = new Startup();
            var serviceProvider = startup.ConfigureServices();
            var service = serviceProvider.GetService<IMainService>();

            service?.Invoke();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }



    }
}