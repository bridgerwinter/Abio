using Abio.Library.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Abio.Library.Actions
{
    public class CombatResult
    {
        public List<Unit> Army1 { get; set; }
        public List<Unit> Army2 { get; set; }
        public string CombatLog { get; set; }
        public List<Unit> Casualties1 { get; set; }
        public List<Unit> Casualties2 { get; set; }
    }
}
