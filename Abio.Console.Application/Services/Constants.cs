using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Abio.Console.Application.Services
{
    internal class Constants
    {        
        private static HttpClient client = new HttpClient();
        public static HttpClient GetClient()
        {
            return client;
        }
        public static string RestUrl = "http://localhost:5096/api/";

		public static string BuildingUrl = string.Concat(RestUrl,"Buildings");
		public static string BuildingLevelUrl = string.Concat(RestUrl,"BuildingLevel");
		public static string ConstructedBuildingUrl = string.Concat(RestUrl,"ConstructedBuildings");
		public static string FactionUrl = string.Concat(RestUrl,"Factions");
		public static string HiredLeaderUrl = string.Concat(RestUrl,"HiredLeaders");
		public static string HiredLeaderStatUrl = string.Concat(RestUrl,"HiredLeaderStats");
		public static string HiredUnitUrl = string.Concat(RestUrl,"HiredUnits");
		public static string HiredUnitAttributeUrl = string.Concat(RestUrl,"HiredUnitAttributes");
		public static string HiredUnitStatUrl = string.Concat(RestUrl,"HiredUnitStats");
		public static string ItemUrl = string.Concat(RestUrl,"Items");
		public static string ItemInventoryUrl = string.Concat(RestUrl,"ItemInventorys");
		public static string MarketUrl = string.Concat(RestUrl,"Markets");
		public static string MarketListingUrl = string.Concat(RestUrl,"MarketListings");
		public static string ResearchedTechnologyUrl = string.Concat(RestUrl,"ResearchedTechnologys");
		public static string ResourceUrl = string.Concat(RestUrl,"Resources");
		public static string ResourceInventoryUrl = string.Concat(RestUrl,"ResourceInventorys");
		public static string TechnologyUrl = string.Concat(RestUrl,"Technologys");
		public static string UnitUrl = string.Concat(RestUrl,"Units");
		public static string UnitAttributeUrl = string.Concat(RestUrl,"UnitAttributes");
		public static string UnitGroupUrl = string.Concat(RestUrl,"UnitGroups");
		public static string UnitLevelUrl = string.Concat(RestUrl,"UnitLevels");
		public static string UnitStatUrl = string.Concat(RestUrl,"UnitStats");
		public static string UserUrl = string.Concat(RestUrl,"Users");
		public static string UserCityUrl = string.Concat(RestUrl,"UserCitys");
		public static string UserCityLeaderUrl = string.Concat(RestUrl,"UserCityLeaders");
	}
}