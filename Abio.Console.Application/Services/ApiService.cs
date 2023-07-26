using Abio.WS.API.DatabaseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abio.Library.Services
{
    public class ApiService
    {

        public static async Task<List<Unit>> GetUnits()
        {
            string result = await Constants.GetClient().GetStringAsync(Constants.UnitUrl);
            var unit = JsonConvert.DeserializeObject<List<Unit>>(result);
            return unit;
        }
        public static async Task<HttpResponseMessage> PostUnit(Unit unit)
        {
            string jsonChore = JsonConvert.SerializeObject(unit);
            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
            HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UnitUrl, httpContent);
            return result;
        }
    }
}
