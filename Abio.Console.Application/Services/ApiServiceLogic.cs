using Abio.Library.DatabaseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abio.Console.Application.Services
{
    public partial class ApiService
    {
        public static async Task<Unit> GetUnitByName(string name)
        {
            var url = Constants.UnitUrl + "/name/" + name;
            string result = await Constants.GetClient().GetStringAsync(url);
            var deserializedResult = JsonConvert.DeserializeObject<Unit>(result);
            return deserializedResult;
        }
    }
}
