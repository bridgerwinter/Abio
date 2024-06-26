﻿using Abio.Library.DatabaseModels;
using Abio.Library.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abio.Library.Services
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

        public static async Task<ResourceGain> GetLastAccessedResource(Guid resourceGainId)
        {
            var url = Constants.ResourceGainUrl + "/" + resourceGainId;
            string result = await Constants.GetClient().GetStringAsync(url);
            var deserializedResult = JsonConvert.DeserializeObject<ResourceGain>(result);
            return deserializedResult;
        }

        public static async Task<List<ResourceInventory>> GetResourceInventoryByUser(Guid id)
        {
            var url = Constants.ResourceInventoryUrl+ "/user/" + id;
            string result = await Constants.GetClient().GetStringAsync(url);
            var deserializedResult = JsonConvert.DeserializeObject<List<ResourceInventory>>(result);
            return deserializedResult;
        }
    }
}
