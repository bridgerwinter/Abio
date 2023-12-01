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
        private static HttpClient client = new HttpClient();
        public static HttpClient GetClient()
        {
            return client;
        }
        public static string RestUrl = "http://localhost:5096/api/";

		public static string MarketUrl = string.Concat(RestUrl,"Markets");
		public static string MarketListingUrl = string.Concat(RestUrl,"MarketListings");
		public static string ConstructedBuildingUrl = string.Concat(RestUrl,"ConstructedBuildings");
		public static string HiredLeaderUrl = string.Concat(RestUrl,"HiredLeaders");
		public static string HiredLeaderStatUrl = string.Concat(RestUrl,"HiredLeaderStats");
		public static string HiredUnitUrl = string.Concat(RestUrl,"HiredUnits");
		public static string HiredUnitStatUrl = string.Concat(RestUrl,"HiredUnitStats");
		public static string HiredUnitStatBodyUrl = string.Concat(RestUrl,"HiredUnitStatBodys");
		public static string HiredUnitStatCivilUrl = string.Concat(RestUrl,"HiredUnitStatCivils");
		public static string HiredUnitStatCombatUrl = string.Concat(RestUrl,"HiredUnitStatCombats");
		public static string HiredUnitStatEmotionUrl = string.Concat(RestUrl,"HiredUnitStatEmotions");
		public static string HiredUnitStatFeatUrl = string.Concat(RestUrl,"HiredUnitStatFeats");
		public static string HiredUnitStatMagicUrl = string.Concat(RestUrl,"HiredUnitStatMagics");
		public static string ItemInventoryUrl = string.Concat(RestUrl,"ItemInventorys");
		public static string ResearchedTechnologyUrl = string.Concat(RestUrl,"ResearchedTechnologys");
		public static string ResourceInventoryUrl = string.Concat(RestUrl,"ResourceInventorys");
		public static string UserCityUrl = string.Concat(RestUrl,"UserCitys");
		public static string UserCityLeaderUrl = string.Concat(RestUrl,"UserCityLeaders");
		public static string UserUrl = string.Concat(RestUrl,"Users");
		public static string AttributeUrl = string.Concat(RestUrl,"Attributes");
		public static string BodyPartUrl = string.Concat(RestUrl,"BodyParts");
		public static string BuildingUrl = string.Concat(RestUrl,"Buildings");
		public static string BuildingLevelUrl = string.Concat(RestUrl,"BuildingLevels");
		public static string EmotionUrl = string.Concat(RestUrl,"Emotions");
		public static string FactionUrl = string.Concat(RestUrl,"Factions");
		public static string FeatUrl = string.Concat(RestUrl,"Feats");
		public static string ItemUrl = string.Concat(RestUrl,"Items");
		public static string PersonalityTraitUrl = string.Concat(RestUrl,"PersonalityTraits");
		public static string ResourceUrl = string.Concat(RestUrl,"Resources");
		public static string SkillUrl = string.Concat(RestUrl,"Skills");
		public static string TechnologyUrl = string.Concat(RestUrl,"Technologys");
		public static string UnitUrl = string.Concat(RestUrl,"Units");
		public static string UnitLevelUrl = string.Concat(RestUrl,"UnitLevels");
	}
}