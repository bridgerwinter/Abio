using Abio.Library.Services;
using Abio.Test.Client.Business.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abio.Test.Client.Business.ApiHelper
{
    public class HireUnitHelper
    {
        public static async Task HireUnitAsync(int unitId)
        {
            HiredUnitDefaultBuilder hiredUnitDefaultBuilder = new HiredUnitDefaultBuilder();
            // Pass this off to the server to find the unit
            //var unit = await ApiService.GetUnit(unitId);
            //var hiredUnit = hiredUnitDefaultBuilder.Build(unit);
            //await ApiService.CreateHiredUnit(hiredUnit);
        }
    }
}
