using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abio.Test.Client.Data.Models
{
    public partial class InterfaceUnit : Abio.Library.DatabaseModels.Unit
    {
        public string InterfaceDescription
        {
            get
            {
                return this.UnitName + Environment.NewLine + this.UnitDescription;
            }
        }
    }
}
