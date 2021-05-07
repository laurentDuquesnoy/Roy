using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConfigDemo.Settings
{
    /// <summary>
    /// Class die de sectie "PersonSettings" representeert in appsettings.json file
    /// </summary>
    public class PersonSettings
    {
        public string DeveloperName { get; set; }
        public string School { get; set; }
        public int Year { get; set; }
    }
}
