using Abio.Library.DatabaseModels;
using Abio.Test.Client.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abio.Test.Client.Business.Builder
{
    public class HiredUnitDefaultBuilder
    {
        readonly Guid testguid = Guid.Parse("77754478-B688-42FB-BD4C-26E3831F1E2B");

        public HiredUnit Build(Unit unit)
        {
            HiredUnit hiredUnit = new HiredUnit();
            hiredUnit.Name = unit.UnitName;
            hiredUnit.Age = (byte?)new Random().Next(18,45);
            hiredUnit.UnitId = unit.UnitId;
            hiredUnit.UserId = testguid;

            hiredUnit.HiredUnitStat = HiredUnitStatBuilder();
            return hiredUnit;
        }

        public HiredUnitStat HiredUnitStatBuilder()
        {
            HiredUnitStat stat = new HiredUnitStat();
            stat.HiredUnitStatBody = HiredUnitStatBodyBuilder();
            stat.HiredUnitStatCivil = HiredUnitStatCivilBuilder();
            stat.HiredUnitStatCombat = HiredUnitStatCombatBuilder();
            stat.HiredUnitStatMagic = HiredUnitStatMagicBuilder();
            return stat;
        }
        public HiredUnitStatBody HiredUnitStatBodyBuilder()
        {
            HiredUnitStatBody statBody = new HiredUnitStatBody();
            return statBody;
        }
        public HiredUnitStatCivil HiredUnitStatCivilBuilder()
        {
            HiredUnitStatCivil statCivil = new HiredUnitStatCivil();
            statCivil.Adaptability = 10;
            statCivil.Artifice = 5;
            statCivil.Comedy = 100;
            return statCivil;
        }
        public HiredUnitStatCombat HiredUnitStatCombatBuilder()
        {
            HiredUnitStatCombat statCombat = new HiredUnitStatCombat();
            statCombat.ShortBlade = 10;
            statCombat.Staff = 15;
            statCombat.MeleeDefence = 1;
            return statCombat;
        }
        public HiredUnitStatMagic HiredUnitStatMagicBuilder()
        {
            HiredUnitStatMagic statMagic = new HiredUnitStatMagic();
            return statMagic;

        }
    }
}
