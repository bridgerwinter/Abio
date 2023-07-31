using Abio.Library.DatabaseModels;
using Newtonsoft.Json;
using System.Text;

namespace Abio.Console.Application.Services
{
	public class ApiService
	{
		public static async Task<List<Building>> GetBuildings()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.BuildingUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Building>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostBuilding(Building building)
		{
			string jsonChore = JsonConvert.SerializeObject(building);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.BuildingUrl,httpContent);
			return result;
		}

		public static async Task<List<BuildingsLevel>> GetBuildingsLevels()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.BuildingsLevelUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<BuildingsLevel>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostBuildingsLevel(BuildingsLevel buildingsLevel)
		{
			string jsonChore = JsonConvert.SerializeObject(buildingsLevel);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.BuildingsLevelUrl,httpContent);
			return result;
		}

		public static async Task<List<ConstructedBuilding>> GetConstructedBuildings()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.ConstructedBuildingUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<ConstructedBuilding>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostConstructedBuilding(ConstructedBuilding constructedBuilding)
		{
			string jsonChore = JsonConvert.SerializeObject(constructedBuilding);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ConstructedBuildingUrl,httpContent);
			return result;
		}

		public static async Task<List<Faction>> GetFactions()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.FactionUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Faction>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostFaction(Faction faction)
		{
			string jsonChore = JsonConvert.SerializeObject(faction);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.FactionUrl,httpContent);
			return result;
		}

		public static async Task<List<Friend>> GetFriends()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.FriendUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Friend>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostFriend(Friend friend)
		{
			string jsonChore = JsonConvert.SerializeObject(friend);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.FriendUrl,httpContent);
			return result;
		}

		public static async Task<List<HiredLeader>> GetHiredLeaders()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.HiredLeaderUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredLeader>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostHiredLeader(HiredLeader hiredLeader)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredLeader);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredLeaderUrl,httpContent);
			return result;
		}

		public static async Task<List<HiredLeaderStat>> GetHiredLeaderStats()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.HiredLeaderStatUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredLeaderStat>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostHiredLeaderStat(HiredLeaderStat hiredLeaderStat)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredLeaderStat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredLeaderStatUrl,httpContent);
			return result;
		}

		public static async Task<List<HiredUnit>> GetHiredUnits()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.HiredUnitUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnit>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostHiredUnit(HiredUnit hiredUnit)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredUnit);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitUrl,httpContent);
			return result;
		}

		public static async Task<List<HiredUnitsStat>> GetHiredUnitsStats()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.HiredUnitsStatUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnitsStat>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostHiredUnitsStat(HiredUnitsStat hiredUnitsStat)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredUnitsStat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitsStatUrl,httpContent);
			return result;
		}

		public static async Task<List<Item>> GetItems()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.ItemUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Item>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostItem(Item item)
		{
			string jsonChore = JsonConvert.SerializeObject(item);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ItemUrl,httpContent);
			return result;
		}

		public static async Task<List<ItemInventory>> GetItemInventorys()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.ItemInventoryUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<ItemInventory>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostItemInventory(ItemInventory itemInventory)
		{
			string jsonChore = JsonConvert.SerializeObject(itemInventory);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ItemInventoryUrl,httpContent);
			return result;
		}

		public static async Task<List<Market>> GetMarkets()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.MarketUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Market>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostMarket(Market market)
		{
			string jsonChore = JsonConvert.SerializeObject(market);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.MarketUrl,httpContent);
			return result;
		}

		public static async Task<List<MarketListing>> GetMarketListings()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.MarketListingUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<MarketListing>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostMarketListing(MarketListing marketListing)
		{
			string jsonChore = JsonConvert.SerializeObject(marketListing);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.MarketListingUrl,httpContent);
			return result;
		}

		public static async Task<List<Player>> GetPlayers()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.PlayerUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Player>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostPlayer(Player player)
		{
			string jsonChore = JsonConvert.SerializeObject(player);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.PlayerUrl,httpContent);
			return result;
		}

		public static async Task<List<ResearchedTechnology>> GetResearchedTechnologys()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.ResearchedTechnologyUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<ResearchedTechnology>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostResearchedTechnology(ResearchedTechnology researchedTechnology)
		{
			string jsonChore = JsonConvert.SerializeObject(researchedTechnology);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ResearchedTechnologyUrl,httpContent);
			return result;
		}

		public static async Task<List<Resource>> GetResources()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.ResourceUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Resource>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostResource(Resource resource)
		{
			string jsonChore = JsonConvert.SerializeObject(resource);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ResourceUrl,httpContent);
			return result;
		}

		public static async Task<List<ResourceInventory>> GetResourceInventorys()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.ResourceInventoryUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<ResourceInventory>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostResourceInventory(ResourceInventory resourceInventory)
		{
			string jsonChore = JsonConvert.SerializeObject(resourceInventory);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ResourceInventoryUrl,httpContent);
			return result;
		}

		public static async Task<List<Technology>> GetTechnologys()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.TechnologyUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Technology>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostTechnology(Technology technology)
		{
			string jsonChore = JsonConvert.SerializeObject(technology);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.TechnologyUrl,httpContent);
			return result;
		}

		public static async Task<List<Unit>> GetUnits()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.UnitUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Unit>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostUnit(Unit unit)
		{
			string jsonChore = JsonConvert.SerializeObject(unit);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UnitUrl,httpContent);
			return result;
		}

		public static async Task<List<UnitGroup>> GetUnitGroups()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.UnitGroupUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<UnitGroup>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostUnitGroup(UnitGroup unitGroup)
		{
			string jsonChore = JsonConvert.SerializeObject(unitGroup);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UnitGroupUrl,httpContent);
			return result;
		}

		public static async Task<List<UnitLevel>> GetUnitLevels()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.UnitLevelUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<UnitLevel>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostUnitLevel(UnitLevel unitLevel)
		{
			string jsonChore = JsonConvert.SerializeObject(unitLevel);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UnitLevelUrl,httpContent);
			return result;
		}

		public static async Task<List<User>> GetUsers()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.UserUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<User>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostUser(User user)
		{
			string jsonChore = JsonConvert.SerializeObject(user);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UserUrl,httpContent);
			return result;
		}

		public static async Task<List<UserCitiesLeader>> GetUserCitiesLeaders()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.UserCitiesLeaderUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<UserCitiesLeader>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostUserCitiesLeader(UserCitiesLeader userCitiesLeader)
		{
			string jsonChore = JsonConvert.SerializeObject(userCitiesLeader);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UserCitiesLeaderUrl,httpContent);
			return result;
		}

		public static async Task<List<UserCity>> GetUserCitys()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.UserCityUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<UserCity>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> PostUserCity(UserCity userCity)
		{
			string jsonChore = JsonConvert.SerializeObject(userCity);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UserCityUrl,httpContent);
			return result;
		}

	}
}