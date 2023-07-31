using Abio.Library.DatabaseModels;
using Newtonsoft.Json;
using System.Text;

namespace Abio.Console.Application.Services
{
	public class ApiService
	{
		public static async Task<HttpResponseMessage> CreateBuilding(Building building)
		{
			string jsonChore = JsonConvert.SerializeObject(building);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.BuildingUrl,httpContent);
			return result;
		}

		public static async Task<Building> GetBuilding(Guid id)
		{
			var url = Constants.BuildingUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Building>(result);
			return deserializedResult;
		}

		public static async Task<List<Building>> GetAllBuildings()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.BuildingUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Building>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateBuilding(Building building)
		{
			var url = Constants.BuildingUrl + building.BuildingId.ToString();
			string jsonChore = JsonConvert.SerializeObject(building);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteBuilding(Building building)
		{
			 var url = Constants.BuildingUrl + building.BuildingId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateBuildingLevel(BuildingLevel buildingLevel)
		{
			string jsonChore = JsonConvert.SerializeObject(buildingLevel);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.BuildingLevelUrl,httpContent);
			return result;
		}

		public static async Task<BuildingLevel> GetBuildingLevel(Guid id)
		{
			var url = Constants.BuildingLevelUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<BuildingLevel>(result);
			return deserializedResult;
		}

		public static async Task<List<BuildingLevel>> GetAllBuildingLevels()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.BuildingLevelUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<BuildingLevel>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateBuildingLevel(BuildingLevel buildingLevel)
		{
			var url = Constants.BuildingLevelUrl + buildingLevel.BuildingLevelId.ToString();
			string jsonChore = JsonConvert.SerializeObject(buildingLevel);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteBuildingLevel(BuildingLevel buildingLevel)
		{
			 var url = Constants.BuildingLevelUrl + buildingLevel.BuildingLevelId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateConstructedBuilding(ConstructedBuilding constructedBuilding)
		{
			string jsonChore = JsonConvert.SerializeObject(constructedBuilding);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ConstructedBuildingUrl,httpContent);
			return result;
		}

		public static async Task<ConstructedBuilding> GetConstructedBuilding(Guid id)
		{
			var url = Constants.ConstructedBuildingUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<ConstructedBuilding>(result);
			return deserializedResult;
		}

		public static async Task<List<ConstructedBuilding>> GetAllConstructedBuildings()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.ConstructedBuildingUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<ConstructedBuilding>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateConstructedBuilding(ConstructedBuilding constructedBuilding)
		{
			var url = Constants.ConstructedBuildingUrl + constructedBuilding.ConstructedBuildingId.ToString();
			string jsonChore = JsonConvert.SerializeObject(constructedBuilding);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteConstructedBuilding(ConstructedBuilding constructedBuilding)
		{
			 var url = Constants.ConstructedBuildingUrl + constructedBuilding.ConstructedBuildingId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateFaction(Faction faction)
		{
			string jsonChore = JsonConvert.SerializeObject(faction);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.FactionUrl,httpContent);
			return result;
		}

		public static async Task<Faction> GetFaction(Guid id)
		{
			var url = Constants.FactionUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Faction>(result);
			return deserializedResult;
		}

		public static async Task<List<Faction>> GetAllFactions()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.FactionUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Faction>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateFaction(Faction faction)
		{
			var url = Constants.FactionUrl + faction.FactionId.ToString();
			string jsonChore = JsonConvert.SerializeObject(faction);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteFaction(Faction faction)
		{
			 var url = Constants.FactionUrl + faction.FactionId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateHiredLeader(HiredLeader hiredLeader)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredLeader);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredLeaderUrl,httpContent);
			return result;
		}

		public static async Task<HiredLeader> GetHiredLeader(Guid id)
		{
			var url = Constants.HiredLeaderUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredLeader>(result);
			return deserializedResult;
		}

		public static async Task<List<HiredLeader>> GetAllHiredLeaders()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.HiredLeaderUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredLeader>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateHiredLeader(HiredLeader hiredLeader)
		{
			var url = Constants.HiredLeaderUrl + hiredLeader.HiredLeaderId.ToString();
			string jsonChore = JsonConvert.SerializeObject(hiredLeader);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteHiredLeader(HiredLeader hiredLeader)
		{
			 var url = Constants.HiredLeaderUrl + hiredLeader.HiredLeaderId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateHiredLeaderStat(HiredLeaderStat hiredLeaderStat)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredLeaderStat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredLeaderStatUrl,httpContent);
			return result;
		}

		public static async Task<HiredLeaderStat> GetHiredLeaderStat(Guid id)
		{
			var url = Constants.HiredLeaderStatUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredLeaderStat>(result);
			return deserializedResult;
		}

		public static async Task<List<HiredLeaderStat>> GetAllHiredLeaderStats()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.HiredLeaderStatUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredLeaderStat>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateHiredLeaderStat(HiredLeaderStat hiredLeaderStat)
		{
			var url = Constants.HiredLeaderStatUrl + hiredLeaderStat.HiredLeaderStatId.ToString();
			string jsonChore = JsonConvert.SerializeObject(hiredLeaderStat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteHiredLeaderStat(HiredLeaderStat hiredLeaderStat)
		{
			 var url = Constants.HiredLeaderStatUrl + hiredLeaderStat.HiredLeaderStatId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateHiredUnit(HiredUnit hiredUnit)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredUnit);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitUrl,httpContent);
			return result;
		}

		public static async Task<HiredUnit> GetHiredUnit(Guid id)
		{
			var url = Constants.HiredUnitUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnit>(result);
			return deserializedResult;
		}

		public static async Task<List<HiredUnit>> GetAllHiredUnits()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.HiredUnitUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnit>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateHiredUnit(HiredUnit hiredUnit)
		{
			var url = Constants.HiredUnitUrl + hiredUnit.HiredUnitId.ToString();
			string jsonChore = JsonConvert.SerializeObject(hiredUnit);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteHiredUnit(HiredUnit hiredUnit)
		{
			 var url = Constants.HiredUnitUrl + hiredUnit.HiredUnitId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateHiredUnitStat(HiredUnitStat hiredUnitStat)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredUnitStat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitStatUrl,httpContent);
			return result;
		}

		public static async Task<HiredUnitStat> GetHiredUnitStat(Guid id)
		{
			var url = Constants.HiredUnitStatUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnitStat>(result);
			return deserializedResult;
		}

		public static async Task<List<HiredUnitStat>> GetAllHiredUnitStats()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.HiredUnitStatUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnitStat>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateHiredUnitStat(HiredUnitStat hiredUnitStat)
		{
			var url = Constants.HiredUnitStatUrl + hiredUnitStat.HiredUnitStatId.ToString();
			string jsonChore = JsonConvert.SerializeObject(hiredUnitStat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteHiredUnitStat(HiredUnitStat hiredUnitStat)
		{
			 var url = Constants.HiredUnitStatUrl + hiredUnitStat.HiredUnitStatId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateItem(Item item)
		{
			string jsonChore = JsonConvert.SerializeObject(item);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ItemUrl,httpContent);
			return result;
		}

		public static async Task<Item> GetItem(Guid id)
		{
			var url = Constants.ItemUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Item>(result);
			return deserializedResult;
		}

		public static async Task<List<Item>> GetAllItems()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.ItemUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Item>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateItem(Item item)
		{
			var url = Constants.ItemUrl + item.ItemId.ToString();
			string jsonChore = JsonConvert.SerializeObject(item);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteItem(Item item)
		{
			 var url = Constants.ItemUrl + item.ItemId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateItemInventory(ItemInventory itemInventory)
		{
			string jsonChore = JsonConvert.SerializeObject(itemInventory);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ItemInventoryUrl,httpContent);
			return result;
		}

		public static async Task<ItemInventory> GetItemInventory(Guid id)
		{
			var url = Constants.ItemInventoryUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<ItemInventory>(result);
			return deserializedResult;
		}

		public static async Task<List<ItemInventory>> GetAllItemInventorys()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.ItemInventoryUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<ItemInventory>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateItemInventory(ItemInventory itemInventory)
		{
			var url = Constants.ItemInventoryUrl + itemInventory.ItemInventoryId.ToString();
			string jsonChore = JsonConvert.SerializeObject(itemInventory);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteItemInventory(ItemInventory itemInventory)
		{
			 var url = Constants.ItemInventoryUrl + itemInventory.ItemInventoryId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateMarket(Market market)
		{
			string jsonChore = JsonConvert.SerializeObject(market);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.MarketUrl,httpContent);
			return result;
		}

		public static async Task<Market> GetMarket(Guid id)
		{
			var url = Constants.MarketUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Market>(result);
			return deserializedResult;
		}

		public static async Task<List<Market>> GetAllMarkets()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.MarketUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Market>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateMarket(Market market)
		{
			var url = Constants.MarketUrl + market.MarketId.ToString();
			string jsonChore = JsonConvert.SerializeObject(market);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteMarket(Market market)
		{
			 var url = Constants.MarketUrl + market.MarketId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateMarketListing(MarketListing marketListing)
		{
			string jsonChore = JsonConvert.SerializeObject(marketListing);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.MarketListingUrl,httpContent);
			return result;
		}

		public static async Task<MarketListing> GetMarketListing(Guid id)
		{
			var url = Constants.MarketListingUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<MarketListing>(result);
			return deserializedResult;
		}

		public static async Task<List<MarketListing>> GetAllMarketListings()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.MarketListingUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<MarketListing>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateMarketListing(MarketListing marketListing)
		{
			var url = Constants.MarketListingUrl + marketListing.MarketListingId.ToString();
			string jsonChore = JsonConvert.SerializeObject(marketListing);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteMarketListing(MarketListing marketListing)
		{
			 var url = Constants.MarketListingUrl + marketListing.MarketListingId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateResearchedTechnology(ResearchedTechnology researchedTechnology)
		{
			string jsonChore = JsonConvert.SerializeObject(researchedTechnology);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ResearchedTechnologyUrl,httpContent);
			return result;
		}

		public static async Task<ResearchedTechnology> GetResearchedTechnology(Guid id)
		{
			var url = Constants.ResearchedTechnologyUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<ResearchedTechnology>(result);
			return deserializedResult;
		}

		public static async Task<List<ResearchedTechnology>> GetAllResearchedTechnologys()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.ResearchedTechnologyUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<ResearchedTechnology>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateResearchedTechnology(ResearchedTechnology researchedTechnology)
		{
			var url = Constants.ResearchedTechnologyUrl + researchedTechnology.ResearchedTechnologyId.ToString();
			string jsonChore = JsonConvert.SerializeObject(researchedTechnology);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteResearchedTechnology(ResearchedTechnology researchedTechnology)
		{
			 var url = Constants.ResearchedTechnologyUrl + researchedTechnology.ResearchedTechnologyId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateResource(Resource resource)
		{
			string jsonChore = JsonConvert.SerializeObject(resource);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ResourceUrl,httpContent);
			return result;
		}

		public static async Task<Resource> GetResource(Guid id)
		{
			var url = Constants.ResourceUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Resource>(result);
			return deserializedResult;
		}

		public static async Task<List<Resource>> GetAllResources()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.ResourceUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Resource>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateResource(Resource resource)
		{
			var url = Constants.ResourceUrl + resource.ResourceId.ToString();
			string jsonChore = JsonConvert.SerializeObject(resource);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteResource(Resource resource)
		{
			 var url = Constants.ResourceUrl + resource.ResourceId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateResourceInventory(ResourceInventory resourceInventory)
		{
			string jsonChore = JsonConvert.SerializeObject(resourceInventory);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ResourceInventoryUrl,httpContent);
			return result;
		}

		public static async Task<ResourceInventory> GetResourceInventory(Guid id)
		{
			var url = Constants.ResourceInventoryUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<ResourceInventory>(result);
			return deserializedResult;
		}

		public static async Task<List<ResourceInventory>> GetAllResourceInventorys()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.ResourceInventoryUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<ResourceInventory>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateResourceInventory(ResourceInventory resourceInventory)
		{
			var url = Constants.ResourceInventoryUrl + resourceInventory.ResourceInventoryId.ToString();
			string jsonChore = JsonConvert.SerializeObject(resourceInventory);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteResourceInventory(ResourceInventory resourceInventory)
		{
			 var url = Constants.ResourceInventoryUrl + resourceInventory.ResourceInventoryId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateTechnology(Technology technology)
		{
			string jsonChore = JsonConvert.SerializeObject(technology);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.TechnologyUrl,httpContent);
			return result;
		}

		public static async Task<Technology> GetTechnology(Guid id)
		{
			var url = Constants.TechnologyUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Technology>(result);
			return deserializedResult;
		}

		public static async Task<List<Technology>> GetAllTechnologys()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.TechnologyUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Technology>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateTechnology(Technology technology)
		{
			var url = Constants.TechnologyUrl + technology.TechnologyId.ToString();
			string jsonChore = JsonConvert.SerializeObject(technology);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteTechnology(Technology technology)
		{
			 var url = Constants.TechnologyUrl + technology.TechnologyId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateUnit(Unit unit)
		{
			string jsonChore = JsonConvert.SerializeObject(unit);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UnitUrl,httpContent);
			return result;
		}

		public static async Task<Unit> GetUnit(Guid id)
		{
			var url = Constants.UnitUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Unit>(result);
			return deserializedResult;
		}

		public static async Task<List<Unit>> GetAllUnits()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.UnitUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Unit>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateUnit(Unit unit)
		{
			var url = Constants.UnitUrl + unit.UnitId.ToString();
			string jsonChore = JsonConvert.SerializeObject(unit);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteUnit(Unit unit)
		{
			 var url = Constants.UnitUrl + unit.UnitId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateUnitGroup(UnitGroup unitGroup)
		{
			string jsonChore = JsonConvert.SerializeObject(unitGroup);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UnitGroupUrl,httpContent);
			return result;
		}

		public static async Task<UnitGroup> GetUnitGroup(Guid id)
		{
			var url = Constants.UnitGroupUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<UnitGroup>(result);
			return deserializedResult;
		}

		public static async Task<List<UnitGroup>> GetAllUnitGroups()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.UnitGroupUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<UnitGroup>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateUnitGroup(UnitGroup unitGroup)
		{
			var url = Constants.UnitGroupUrl + unitGroup.UnitGroupId.ToString();
			string jsonChore = JsonConvert.SerializeObject(unitGroup);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteUnitGroup(UnitGroup unitGroup)
		{
			 var url = Constants.UnitGroupUrl + unitGroup.UnitGroupId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateUnitLevel(UnitLevel unitLevel)
		{
			string jsonChore = JsonConvert.SerializeObject(unitLevel);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UnitLevelUrl,httpContent);
			return result;
		}

		public static async Task<UnitLevel> GetUnitLevel(Guid id)
		{
			var url = Constants.UnitLevelUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<UnitLevel>(result);
			return deserializedResult;
		}

		public static async Task<List<UnitLevel>> GetAllUnitLevels()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.UnitLevelUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<UnitLevel>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateUnitLevel(UnitLevel unitLevel)
		{
			var url = Constants.UnitLevelUrl + unitLevel.UnitLevelId.ToString();
			string jsonChore = JsonConvert.SerializeObject(unitLevel);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteUnitLevel(UnitLevel unitLevel)
		{
			 var url = Constants.UnitLevelUrl + unitLevel.UnitLevelId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateUser(User user)
		{
			string jsonChore = JsonConvert.SerializeObject(user);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UserUrl,httpContent);
			return result;
		}

		public static async Task<User> GetUser(Guid id)
		{
			var url = Constants.UserUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<User>(result);
			return deserializedResult;
		}

		public static async Task<List<User>> GetAllUsers()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.UserUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<User>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateUser(User user)
		{
			var url = Constants.UserUrl + user.UserId.ToString();
			string jsonChore = JsonConvert.SerializeObject(user);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteUser(User user)
		{
			 var url = Constants.UserUrl + user.UserId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateUserCity(UserCity userCity)
		{
			string jsonChore = JsonConvert.SerializeObject(userCity);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UserCityUrl,httpContent);
			return result;
		}

		public static async Task<UserCity> GetUserCity(Guid id)
		{
			var url = Constants.UserCityUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<UserCity>(result);
			return deserializedResult;
		}

		public static async Task<List<UserCity>> GetAllUserCitys()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.UserCityUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<UserCity>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateUserCity(UserCity userCity)
		{
			var url = Constants.UserCityUrl + userCity.UserCityId.ToString();
			string jsonChore = JsonConvert.SerializeObject(userCity);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteUserCity(UserCity userCity)
		{
			 var url = Constants.UserCityUrl + userCity.UserCityId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateUserCityLeader(UserCityLeader userCityLeader)
		{
			string jsonChore = JsonConvert.SerializeObject(userCityLeader);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UserCityLeaderUrl,httpContent);
			return result;
		}

		public static async Task<UserCityLeader> GetUserCityLeader(Guid id)
		{
			var url = Constants.UserCityLeaderUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<UserCityLeader>(result);
			return deserializedResult;
		}

		public static async Task<List<UserCityLeader>> GetAllUserCityLeaders()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.UserCityLeaderUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<UserCityLeader>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateUserCityLeader(UserCityLeader userCityLeader)
		{
			var url = Constants.UserCityLeaderUrl + userCityLeader.UserCityLeaderId.ToString();
			string jsonChore = JsonConvert.SerializeObject(userCityLeader);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteUserCityLeader(UserCityLeader userCityLeader)
		{
			 var url = Constants.UserCityLeaderUrl + userCityLeader.UserCityLeaderId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

	}
}