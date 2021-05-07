using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONUtils.Data;

namespace JSONUtils
{
    interface IJSONConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="absoluteFolderPath">Het absolute pad van de folder</param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        //  public CustomerConverterResult DeserializeCustomerFromJSONFile(string absoluteFolderPath, string fileName = "customer.json");
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="absoluteFolderPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
       public ConverterResult<T> DeserializeObjectFromJSONFile<T>(string absoluteFolderPath, string fileName);
       
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="absoluteFolderPath"></param>
        /// <param name="fileName"></param>
        /// <param name="objectToSerialize"></param>
        /// <returns></returns>
        public ConverterResult<T> SerializeObjectToJSONFile<T>(string absoluteFolderPath, string fileName, T objectToSerialize);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="absoluteFolderPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        //  public CustomerConverterResult SerializeCustomerToJSONFile(string absoluteFolderPath, string fileName = "customer.json");
    }
}
