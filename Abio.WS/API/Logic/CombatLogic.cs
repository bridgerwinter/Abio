using Abio.Library.Actions;
using Abio.Library.DatabaseModels;

namespace Abio.WS.API.Logic
{
    public class CombatLogic
    {
        public static CombatResult GetCombatResult(CombatMessage combatMessage)
        {
            CombatResult result = new CombatResult();

            var winner = combatMessage.Army1.Count > combatMessage.Army2.Count ? "Army 1" : "Army 2";

            var difference = 0;
            if (winner == "Army 1 Wins")
            {
                difference = combatMessage.Army1.Count - combatMessage.Army2.Count;
                combatMessage.Army2.RemoveRange(0, combatMessage.Army2.Count);
            }
            else
            {
                difference = combatMessage.Army2.Count - combatMessage.Army1.Count;
                combatMessage.Army1.RemoveRange(0, combatMessage.Army1.Count);
            }
            result.Army1 = combatMessage.Army1;
            result.Army2 = combatMessage.Army2;
            result.CombatLog = string.Format("{0} Wins, killing {1} Units", winner, difference);

            return result;
        }
    }
}
