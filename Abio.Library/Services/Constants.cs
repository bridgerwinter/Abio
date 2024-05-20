
using System;
using System.Collections.Generic;
using System.Linq;using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Abio.Library.DatabaseModels;
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

		public static string MarketUrl = $"{RestUrl}Markets";
		public static string MarketListingUrl = $"{RestUrl}MarketListings";
		public static string AttributeUrl = $"{RestUrl}Attributes";
		public static string BodyPartUrl = $"{RestUrl}BodyParts";
		public static string BuildingUrl = $"{RestUrl}Buildings";
		public static string BuildingLevelUrl = $"{RestUrl}BuildingLevels";
		public static string EmotionUrl = $"{RestUrl}Emotions";
		public static string FactionUrl = $"{RestUrl}Factions";
		public static string FeatUrl = $"{RestUrl}Feats";
		public static string ItemUrl = $"{RestUrl}Items";
		public static string PersonalityTraitUrl = $"{RestUrl}PersonalityTraits";
		public static string ResourceUrl = $"{RestUrl}Resources";
		public static string SkillUrl = $"{RestUrl}Skills";
		public static string TechnologyUrl = $"{RestUrl}Technologys";
		public static string UnitUrl = $"{RestUrl}Units";
		public static string UnitLevelUrl = $"{RestUrl}UnitLevels";
		public static string ConstructedBuildingUrl = $"{RestUrl}ConstructedBuildings";
		public static string FriendUrl = $"{RestUrl}Friends";
		public static string HiredLeaderUrl = $"{RestUrl}HiredLeaders";
		public static string HiredLeaderStatUrl = $"{RestUrl}HiredLeaderStats";
		public static string HiredUnitUrl = $"{RestUrl}HiredUnits";
		public static string HiredUnitStatUrl = $"{RestUrl}HiredUnitStats";
		public static string HiredUnitStatBodyUrl = $"{RestUrl}HiredUnitStatBodys";
		public static string HiredUnitStatCivilUrl = $"{RestUrl}HiredUnitStatCivils";
		public static string HiredUnitStatCombatUrl = $"{RestUrl}HiredUnitStatCombats";
		public static string HiredUnitStatEmotionUrl = $"{RestUrl}HiredUnitStatEmotions";
		public static string HiredUnitStatFeatUrl = $"{RestUrl}HiredUnitStatFeats";
		public static string HiredUnitStatMagicUrl = $"{RestUrl}HiredUnitStatMagics";
		public static string ItemInventoryUrl = $"{RestUrl}ItemInventorys";
		public static string PlayerUrl = $"{RestUrl}Players";
		public static string ResearchedTechnologyUrl = $"{RestUrl}ResearchedTechnologys";
		public static string ResourceGainUrl = $"{RestUrl}ResourceGains";
		public static string ResourceInventoryUrl = $"{RestUrl}ResourceInventorys";
		public static string UserCityUrl = $"{RestUrl}UserCitys";
		public static string UserCityLeaderUrl = $"{RestUrl}UserCityLeaders";
		public static string UserUrl = $"{RestUrl}Users";
			
	}
}