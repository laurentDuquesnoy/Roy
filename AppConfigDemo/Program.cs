using AppConfigDemo.Settings; //namespace van de configuratiesettins
using AppConfiguration; //namespace van de class library Appconfiguration
using System;
using AppConfiguration.Data;

namespace AppConfigDemo
{
    class Program
    {

        // We gebruiken  de appSettingService als een  singleton ==> Instance property van de AppSettingsService
        // de AppSettingsService is generiek en wordt geinstancieerd met de Type parameter "DemoAppSettings".
        private static AppSettingsService<DemoAppSettings> _appSettingsService = AppSettingsService<DemoAppSettings>.Instance;

        static void Main(string[] args)
        {
            PrintAppSettings();
        }

        /// <summary>
        /// Gebruik de AppSettings property
        /// </summary>
        public static void PrintAppSettings()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Demo app settings");
            Console.WriteLine("====================");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Person settings");
            Console.WriteLine("---------------");

            Console.ForegroundColor = ConsoleColor.White;
            // gebruik van literal template ==> $"{varname}"
            // ? : als null
            Console.WriteLine($"Developer: {_appSettingsService.AppSettings?.PersonSettings?.DeveloperName}");
            Console.WriteLine($"School: {_appSettingsService.AppSettings?.PersonSettings?.School}");
            Console.WriteLine($"Year: {_appSettingsService.AppSettings?.PersonSettings?.Year}");
            Console.WriteLine("");
        }


        // oefening: schrijf 2 methodes; 1 die enkel de gegevens van PersonSettings haalt en 1 die enkel de gegevens van ProgramSettings haalt.
        // debug de methodes; gebruik step by step debugging en werk je door de commando's zodat je begrijpt wat ze doen!
        
        private static void _printInfoMessage(string message)
        {
            _printMessage(message, ConsoleColor.Cyan);
        }
        private static void _printSuccessMessage(string message)
        {
            _printMessage(message, ConsoleColor.Green);
        }
        private static void _printErrorMessage(string message)
        {
            _printMessage(message, ConsoleColor.Red);
        }

        private static void _printMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public static ConfigurationQueryResult<TSection> GetPersonSettings<TSection>()
        {
            var result = _appSettingsService.GetConfigurationSection<TSection>("PersonSettings");

            return result;
        }

        public static ConfigurationQueryResult<TSection> GetProgramSettings<TSection>()
        {
            var result = _appSettingsService.GetConfigurationSection<TSection>("ProgramSettings");

            return result;
        }
    }
}
