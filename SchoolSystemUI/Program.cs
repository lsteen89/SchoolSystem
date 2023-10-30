using SchoolSystemLibary.Models;
using Serilog;

namespace SchoolSystemUI
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("DapperQueries.txt")
                .CreateLogger();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.Run(new SchoolSystemLogin());// For prod
            // Application.Run(new SchoolSystemMain());  //Debug
            Log.CloseAndFlush(); // Close and flush the log when your application exits
        }
    }
}