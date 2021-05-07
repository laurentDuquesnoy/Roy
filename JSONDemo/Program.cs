using System;
using JSONDemo.Data;
using JSONUtils;
// using JSONUtils.Data;

namespace JSONDemo
{
    class Program
    {
        private static DemoNetCoreJSONConverter _demoNetCoreJSONConverter = new DemoNetCoreJSONConverter();
        static void Main(string[] args)
        {
            _printMenu(true);
        }

        /// <summary>
        /// Print het keuze menu voor de gebruiker
        /// </summary>
        /// <param name="clearScreen"></param>
        private static void _printMenu(bool clearScreen = false)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (clearScreen) Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Read 'customer.json' file to 'Customer' object"); //deserialize
            Console.WriteLine("2) Read 'customer.json' file to 'Customer' object - Generic");  //deserialize
            Console.WriteLine("3) Build 'newCustomer.json' file from 'Customer' object");  //serialize
            Console.WriteLine("4) Build 'newCustomer.json' file from 'Customer' object - Generic"); //serialize
            Console.WriteLine("5) oefening 1");
            Console.WriteLine("6) oefening 2");
            Console.WriteLine("9) Exit");
            Console.Write("\r\nSelect an option: ");

            // wahct op input van de gebuiker: ReadLine()
            switch (Console.ReadLine())
            {
                case "1":
                    {
                       // _readCustomerSettings();
                        _printMenu();
                        break;
                    }
                case "2":
                    {
                        _readObjectSettings<Customer>("customer.json", @"c:\VivesTestFiles");
                        _printMenu();
                        break;
                    }
                case "3":
                    {
                       // _writeCustomerSettings();
                        _printMenu();
                        break;
                    }
                case "4":
                    {
                        var customer = new Customer() { EmailAddress = "", Name = "" };
                        _writeObjectSettings<Customer>(customer,"newCustomer.json");
                        _printMenu();
                        break;
                    }
                case "5":
                    {
                        _printMenu();
                        break;
                    }
                case "6":
                    {
                        _printMenu();
                        break;
                    }
                case "9":
                    {
                        //exit program
                        break;
                    }
                default:
                    {
                        _printMenu();
                        break;
                    }
            }
        }

        /* private static void _readCustomerSettings(string fileName = "customer.json", string folderPath = @"c:\VivesTestFiles")
         {
             // Des
             var result = _demoNetCoreJSONConverter.DeserializeCustomerFromJSONFile(folderPath, fileName);
             if (result.Status == ConverterStatus.HasError)
             {
                 _printErrorMessage(result.Error.Message);
                 return;
             }

             // string interpolation op meerdere lijnen
             var customerSettings = $@"
                     Name: {result.CustomerResult.Name}
                     Premame: {result.CustomerResult.Prename}
                     Email :  {result.CustomerResult.EmailAddress}
                     Phone: {result.CustomerResult.PhoneNumber}
                     ";
             _printInfoMessage(customerSettings);
         }*/

        /*  private static void _writeCustomerSettings(string fileName = "newCustomer.json", string folderPath = @"c:\VivesTestFiles")
          {
              // bad practice; domain model mag niet in helper class
              var result = _demoNetCoreJSONConverter.SerializeCustomerToJSONFile(folderPath, fileName);
              if (result.Status == ConverterStatus.HasError)
              {
                  _printErrorMessage(result.Error.Message);
                  return;
              }
              _printSuccessMessage($"Object of type \"Customer\" was serialized to file {fileName}");
          }*/


        /// <summary>
        /// Generiek methode om een object te maken uit een json bestand.
        /// Maakt gebruik van de DemoNetCoreJSONConverter class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="folderPath"></param>
        private static void _readObjectSettings<T>(string fileName, string folderPath)
        {
            var result = _demoNetCoreJSONConverter.DeserializeObjectFromJSONFile<T>(folderPath, fileName);
            if (result.Status == ConverterStatus.HasError)
            {
                _printErrorMessage(result.Error.Message);
                return;
            }

            // bepaal de properties van het object
            // print de properties en de waarden van de properties van het object
            // LET WEL: dit is een heel basic voorbeeld, wanneer een object andere objecten bevat  (propertie is custom class, list, array, ....) dan is veel meer code nodig
          /*  Type t = typeof(T);
            var objectTypeProperties = t.GetProperties();

            var deserializedObject = result.ReturnValue;
            //gebruik een stringbuilder object om de template te bouwen
            var stringBuilderObjectSettings = new System.Text.StringBuilder();
            foreach (var p in objectTypeProperties)
            {
                stringBuilderObjectSettings.Append($"{p.Name}: { p.GetValue(deserializedObject) }");
                stringBuilderObjectSettings.AppendLine();
            }
            _printInfoMessage(stringBuilderObjectSettings.ToString());*/
            //_printProperties<T>(result.ReturnValue);
        }

        /// <summary>
        /// Generieke methode om een object te serialiseren en weg te schrijven naar een json bestand
        /// Maakt gebruik van de DemoNetCoreJSONConverter class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <param name="fileName"></param>
        /// <param name="absolutefolderPath"></param>
        private static void _writeObjectSettings<T>(T objectToSerialize, string fileName, string absolutefolderPath = @"c:\VivesTestFiles")
        {
            Type objectType = typeof(T);
            fileName = (fileName == null) ? $"{ objectType.Name }.json" : fileName;
            var result = _demoNetCoreJSONConverter.SerializeObjectToJSONFile<T>(absolutefolderPath, fileName, objectToSerialize);
            if (result.Status == ConverterStatus.HasError)
            {
                _printErrorMessage(result.Error.Message);
                return;
            }
            _printSuccessMessage($"Object of type \" { objectType.Name  } \" was serialized to file {fileName}");
        }


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
    }
}
