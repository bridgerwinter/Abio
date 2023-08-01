using Abio.Library.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Abio.Library.Actions
{
    public class CombatMessage
    {
        public List<Unit> Army1 = new List<Unit>();
        public List<Unit> Army2 = new List<Unit>();
        public List<Guid> Users = new List<Guid>();
    }
}
