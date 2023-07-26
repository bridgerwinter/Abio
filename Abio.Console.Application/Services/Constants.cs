using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Abio.Library.Services
{
    internal class Constants
    {
        public static string RestUrl = "http://localhost:5096/api/";
        public static string UnitUrl = "http://localhost:5096/api/Units";
        private static HttpClient client = new HttpClient();
        public static HttpClient GetClient()
        {
            return client;
        }
    }
}
