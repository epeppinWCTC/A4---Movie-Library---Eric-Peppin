using A4___Movie_Library___Eric_Peppin;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

class Program
{
    public static void Main(string[] args)
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        var serviceProvider = serviceCollection
            .AddLogging(x => x.AddConsole())
            .BuildServiceProvider();
        var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();


        logger.LogInformation("Start of program");
        var menu = new Menu();





    }
}