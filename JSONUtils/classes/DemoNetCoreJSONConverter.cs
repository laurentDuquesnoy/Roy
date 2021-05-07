using JSONUtils.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONUtils
{
    public class DemoNetCoreJSONConverter : IJSONConverter
    {
       /* public CustomerConverterResult DeserializeCustomerFromJSONFile(string absoluteFolderPath, string fileName = "customer.json")
        {
            throw new NotImplementedException();
        }*/

        // JSON - Text file lezen
        // https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-read-a-text-file-in-C-Sharp/

        // StreamReader object gebruiker of File object gebruikt
        // Wat is het verschil? ==>
        // https://stackoverflow.com/questions/3545402/any-difference-between-file-readalltext-and-using-a-streamreader-to-read-file

        /* public CustomerConverterResult DeserializeCustomerFromJSONFile(string absoluteFolderPath, string fileName = "customer.json")
          {
              var result = new CustomerConverterResult() { Status = ConverterStatus.Ok };
              var fullFilePath = Path.Combine(absoluteFolderPath, fileName);
              //controleer als de file bestaat binnen het opgegeven absolute folder pad.
              if (File.Exists(fullFilePath))
              {
                //using: disposal of the reader object, weggooien van het object na gebruik
                // ram vrijmaken
                using (var reader = new StreamReader(fullFilePath, System.Text.Encoding.UTF8))
                {
                    // lezen van de inhoud van het json bestand in een string
                    var jsonString = reader.ReadToEnd();
                    reader.Close(); // sluit reader
                                    // Deserialisatie van de JSON Sting in het Customer object
                    result.CustomerResult = System.Text.Json.JsonSerializer.Deserialize<Customer>(jsonString);
                }
              }
              else
              {
                  result.Status = ConverterStatus.HasError;
                  result.Error = new Exception($"Opgegeven file met naam { fileName } bestaat niet!");
              }
              return result;
          }*/

      /*  public CustomerConverterResult SerializeCustomerToJSONFile(string absoluteFolderPath, string fileName = "customer.json")
        {
            var result = new CustomerConverterResult() { Status = ConverterStatus.Ok };
            try
            {
                var fullFilePath = Path.Combine(absoluteFolderPath, fileName);
                // Bad practice: geen domain data in generieke libraries
                var customer = new Customer()
                {
                    Name = "Decaestecker",
                    Prename = "Roy",
                    EmailAddress = "bla@bla.be",
                    PhoneNumber = ""
                };
                // seralisatie van customer object naar een JSON string
                var jsonString = System.Text.Json.JsonSerializer.Serialize<Customer>(customer);

                // schrijf de jsonstring naar de file 
                File.WriteAllText(fullFilePath, jsonString);
            }
            catch (Exception e)
            {
                result.Error = e;
                result.Status = ConverterStatus.HasError;
            }
            return result;
        } */


        /// <summary>
        /// Generieke method om een object te deserialiseren uit een JSON File
        /// </summary>
        /// <typeparam name="TOtds">Type van Object To DeSerialize</typeparam>
        /// <param name="absoluteFolderPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ConverterResult<TOtds> DeserializeObjectFromJSONFile<TOtds>(string absoluteFolderPath, string fileName)
        {
            var result = new ConverterResult<TOtds>() { Status = ConverterStatus.Ok };
            var fullFilePath = Path.Combine(absoluteFolderPath, fileName);
            if (File.Exists(fullFilePath))
            {
                string JSONString = File.ReadAllText(fullFilePath);
                result.ReturnValue = System.Text.Json.JsonSerializer.Deserialize<TOtds>(JSONString);
            }
            else
            {
                result.Status = ConverterStatus.HasError;
                result.Error = new Exception("File does not exist");
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOts">Type van Object To Serialize</typeparam>
        /// <param name="absoluteFolderPath"></param>
        /// <param name="fileName"></param>
        /// <param name="objectToSerialize"></param>
        /// <returns></returns>
        public ConverterResult<TOts> SerializeObjectToJSONFile<TOts>(string absoluteFolderPath, string fileName, TOts objectToSerialize)
        {
            var result = new ConverterResult<TOts>() { Status = ConverterStatus.Ok };
            try
            {
                var fullFilePath = Path.Combine(absoluteFolderPath, fileName);
                var jsonString = System.Text.Json.JsonSerializer.Serialize<TOts>(objectToSerialize);
                File.WriteAllText(fullFilePath, jsonString);
            }
            catch (Exception e)
            {
                result.Error = e;
                result.Status = ConverterStatus.HasError;
            }
            return result;
        }
    }
}
