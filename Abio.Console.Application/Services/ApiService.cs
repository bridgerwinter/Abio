using Abio.Library.DatabaseModels;
using Newtonsoft.Json;
using System.Text;
using Attribute = Abio.Library.DatabaseModels.Attribute;

namespace Abio.Console.Application.Services
{
	public partial class ApiService
	{
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

		public static async Task<HttpResponseMessage> CreateHiredUnitStatBody(HiredUnitStatBody hiredUnitStatBody)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredUnitStatBody);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitStatBodyUrl,httpContent);
			return result;
		}

		public static async Task<HiredUnitStatBody> GetHiredUnitStatBody(Guid id)
		{
			var url = Constants.HiredUnitStatBodyUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnitStatBody>(result);
			return deserializedResult;
		}

		public static async Task<List<HiredUnitStatBody>> GetAllHiredUnitStatBodys()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.HiredUnitStatBodyUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnitStatBody>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateHiredUnitStatBody(HiredUnitStatBody hiredUnitStatBody)
		{
			var url = Constants.HiredUnitStatBodyUrl + hiredUnitStatBody.HiredUnitStatBodyId.ToString();
			string jsonChore = JsonConvert.SerializeObject(hiredUnitStatBody);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteHiredUnitStatBody(HiredUnitStatBody hiredUnitStatBody)
		{
			 var url = Constants.HiredUnitStatBodyUrl + hiredUnitStatBody.HiredUnitStatBodyId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateHiredUnitStatCivil(HiredUnitStatCivil hiredUnitStatCivil)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredUnitStatCivil);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitStatCivilUrl,httpContent);
			return result;
		}

		public static async Task<HiredUnitStatCivil> GetHiredUnitStatCivil(Guid id)
		{
			var url = Constants.HiredUnitStatCivilUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnitStatCivil>(result);
			return deserializedResult;
		}

		public static async Task<List<HiredUnitStatCivil>> GetAllHiredUnitStatCivils()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.HiredUnitStatCivilUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnitStatCivil>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateHiredUnitStatCivil(HiredUnitStatCivil hiredUnitStatCivil)
		{
			var url = Constants.HiredUnitStatCivilUrl + hiredUnitStatCivil.HiredUnitStatCivilId.ToString();
			string jsonChore = JsonConvert.SerializeObject(hiredUnitStatCivil);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteHiredUnitStatCivil(HiredUnitStatCivil hiredUnitStatCivil)
		{
			 var url = Constants.HiredUnitStatCivilUrl + hiredUnitStatCivil.HiredUnitStatCivilId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateHiredUnitStatCombat(HiredUnitStatCombat hiredUnitStatCombat)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredUnitStatCombat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitStatCombatUrl,httpContent);
			return result;
		}

		public static async Task<HiredUnitStatCombat> GetHiredUnitStatCombat(Guid id)
		{
			var url = Constants.HiredUnitStatCombatUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnitStatCombat>(result);
			return deserializedResult;
		}

		public static async Task<List<HiredUnitStatCombat>> GetAllHiredUnitStatCombats()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.HiredUnitStatCombatUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnitStatCombat>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateHiredUnitStatCombat(HiredUnitStatCombat hiredUnitStatCombat)
		{
			var url = Constants.HiredUnitStatCombatUrl + hiredUnitStatCombat.HiredUnitStatCombatId.ToString();
			string jsonChore = JsonConvert.SerializeObject(hiredUnitStatCombat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteHiredUnitStatCombat(HiredUnitStatCombat hiredUnitStatCombat)
		{
			 var url = Constants.HiredUnitStatCombatUrl + hiredUnitStatCombat.HiredUnitStatCombatId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateHiredUnitStatEmotion(HiredUnitStatEmotion hiredUnitStatEmotion)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredUnitStatEmotion);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitStatEmotionUrl,httpContent);
			return result;
		}

		public static async Task<HiredUnitStatEmotion> GetHiredUnitStatEmotion(Guid id)
		{
			var url = Constants.HiredUnitStatEmotionUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnitStatEmotion>(result);
			return deserializedResult;
		}

		public static async Task<List<HiredUnitStatEmotion>> GetAllHiredUnitStatEmotions()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.HiredUnitStatEmotionUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnitStatEmotion>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateHiredUnitStatEmotion(HiredUnitStatEmotion hiredUnitStatEmotion)
		{
			var url = Constants.HiredUnitStatEmotionUrl + hiredUnitStatEmotion.HiredUnitStatEmotionId.ToString();
			string jsonChore = JsonConvert.SerializeObject(hiredUnitStatEmotion);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteHiredUnitStatEmotion(HiredUnitStatEmotion hiredUnitStatEmotion)
		{
			 var url = Constants.HiredUnitStatEmotionUrl + hiredUnitStatEmotion.HiredUnitStatEmotionId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateHiredUnitStatFeat(HiredUnitStatFeat hiredUnitStatFeat)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredUnitStatFeat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitStatFeatUrl,httpContent);
			return result;
		}

		public static async Task<HiredUnitStatFeat> GetHiredUnitStatFeat(Guid id)
		{
			var url = Constants.HiredUnitStatFeatUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnitStatFeat>(result);
			return deserializedResult;
		}

		public static async Task<List<HiredUnitStatFeat>> GetAllHiredUnitStatFeats()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.HiredUnitStatFeatUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnitStatFeat>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateHiredUnitStatFeat(HiredUnitStatFeat hiredUnitStatFeat)
		{
			var url = Constants.HiredUnitStatFeatUrl + hiredUnitStatFeat.HiredUnitStatFeatId.ToString();
			string jsonChore = JsonConvert.SerializeObject(hiredUnitStatFeat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteHiredUnitStatFeat(HiredUnitStatFeat hiredUnitStatFeat)
		{
			 var url = Constants.HiredUnitStatFeatUrl + hiredUnitStatFeat.HiredUnitStatFeatId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateHiredUnitStatMagic(HiredUnitStatMagic hiredUnitStatMagic)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredUnitStatMagic);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitStatMagicUrl,httpContent);
			return result;
		}

		public static async Task<HiredUnitStatMagic> GetHiredUnitStatMagic(Guid id)
		{
			var url = Constants.HiredUnitStatMagicUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnitStatMagic>(result);
			return deserializedResult;
		}

		public static async Task<List<HiredUnitStatMagic>> GetAllHiredUnitStatMagics()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.HiredUnitStatMagicUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnitStatMagic>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateHiredUnitStatMagic(HiredUnitStatMagic hiredUnitStatMagic)
		{
			var url = Constants.HiredUnitStatMagicUrl + hiredUnitStatMagic.HiredUnitStatMagicId.ToString();
			string jsonChore = JsonConvert.SerializeObject(hiredUnitStatMagic);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteHiredUnitStatMagic(HiredUnitStatMagic hiredUnitStatMagic)
		{
			 var url = Constants.HiredUnitStatMagicUrl + hiredUnitStatMagic.HiredUnitStatMagicId.ToString();
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

		public static async Task<HttpResponseMessage> CreateAttribute(Attribute attribute)
		{
			string jsonChore = JsonConvert.SerializeObject(attribute);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.AttributeUrl,httpContent);
			return result;
		}

		public static async Task<Attribute> GetAttribute(int id)
		{
			var url = Constants.AttributeUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Attribute>(result);
			return deserializedResult;
		}

		public static async Task<List<Attribute>> GetAllAttributes()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.AttributeUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Attribute>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateAttribute(Attribute attribute)
		{
			var url = Constants.AttributeUrl + attribute.AttributeId.ToString();
			string jsonChore = JsonConvert.SerializeObject(attribute);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteAttribute(Attribute attribute)
		{
			 var url = Constants.AttributeUrl + attribute.AttributeId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateBodyPart(BodyPart bodyPart)
		{
			string jsonChore = JsonConvert.SerializeObject(bodyPart);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.BodyPartUrl,httpContent);
			return result;
		}

		public static async Task<BodyPart> GetBodyPart(int id)
		{
			var url = Constants.BodyPartUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<BodyPart>(result);
			return deserializedResult;
		}

		public static async Task<List<BodyPart>> GetAllBodyParts()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.BodyPartUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<BodyPart>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateBodyPart(BodyPart bodyPart)
		{
			var url = Constants.BodyPartUrl + bodyPart.BodyPartId.ToString();
			string jsonChore = JsonConvert.SerializeObject(bodyPart);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteBodyPart(BodyPart bodyPart)
		{
			 var url = Constants.BodyPartUrl + bodyPart.BodyPartId.ToString();
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}

		public static async Task<HttpResponseMessage> CreateBuilding(Building building)
		{
			string jsonChore = JsonConvert.SerializeObject(building);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.BuildingUrl,httpContent);
			return result;
		}

		public static async Task<Building> GetBuilding(int id)
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

		public static async Task<BuildingLevel> GetBuildingLevel(int id)
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

		public static async Task<HttpResponseMessage> CreateEmotion(Emotion emotion)
		{
			string jsonChore = JsonConvert.SerializeObject(emotion);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.EmotionUrl,httpContent);
			return result;
		}

		public static async Task<Emotion> GetEmotion(int id)
		{
			var url = Constants.EmotionUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Emotion>(result);
			return deserializedResult;
		}

		public static async Task<List<Emotion>> GetAllEmotions()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.EmotionUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Emotion>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateEmotion(Emotion emotion)
		{
			var url = Constants.EmotionUrl + emotion.EmotionId.ToString();
			string jsonChore = JsonConvert.SerializeObject(emotion);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteEmotion(Emotion emotion)
		{
			 var url = Constants.EmotionUrl + emotion.EmotionId.ToString();
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

		public static async Task<Faction> GetFaction(int id)
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

		public static async Task<HttpResponseMessage> CreateFeat(Feat feat)
		{
			string jsonChore = JsonConvert.SerializeObject(feat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.FeatUrl,httpContent);
			return result;
		}

		public static async Task<Feat> GetFeat(int id)
		{
			var url = Constants.FeatUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Feat>(result);
			return deserializedResult;
		}

		public static async Task<List<Feat>> GetAllFeats()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.FeatUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Feat>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateFeat(Feat feat)
		{
			var url = Constants.FeatUrl + feat.FeatId.ToString();
			string jsonChore = JsonConvert.SerializeObject(feat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteFeat(Feat feat)
		{
			 var url = Constants.FeatUrl + feat.FeatId.ToString();
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

		public static async Task<Item> GetItem(int id)
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

		public static async Task<HttpResponseMessage> CreatePersonalityTrait(PersonalityTrait personalityTrait)
		{
			string jsonChore = JsonConvert.SerializeObject(personalityTrait);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.PersonalityTraitUrl,httpContent);
			return result;
		}

		public static async Task<PersonalityTrait> GetPersonalityTrait(int id)
		{
			var url = Constants.PersonalityTraitUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<PersonalityTrait>(result);
			return deserializedResult;
		}

		public static async Task<List<PersonalityTrait>> GetAllPersonalityTraits()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.PersonalityTraitUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<PersonalityTrait>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdatePersonalityTrait(PersonalityTrait personalityTrait)
		{
			var url = Constants.PersonalityTraitUrl + personalityTrait.PersonalityTraitId.ToString();
			string jsonChore = JsonConvert.SerializeObject(personalityTrait);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeletePersonalityTrait(PersonalityTrait personalityTrait)
		{
			 var url = Constants.PersonalityTraitUrl + personalityTrait.PersonalityTraitId.ToString();
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

		public static async Task<Resource> GetResource(int id)
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

		public static async Task<HttpResponseMessage> CreateSkill(Skill skill)
		{
			string jsonChore = JsonConvert.SerializeObject(skill);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.SkillUrl,httpContent);
			return result;
		}

		public static async Task<Skill> GetSkill(int id)
		{
			var url = Constants.SkillUrl + id.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Skill>(result);
			return deserializedResult;
		}

		public static async Task<List<Skill>> GetAllSkills()
		{
			string result = await Constants.GetClient().GetStringAsync(Constants.SkillUrl);
			var deserializedResult = JsonConvert.DeserializeObject<List<Skill>>(result);
			return deserializedResult;
		}

		public static async Task<HttpResponseMessage> UpdateSkill(Skill skill)
		{
			var url = Constants.SkillUrl + skill.SkillId.ToString();
			string jsonChore = JsonConvert.SerializeObject(skill);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		public static async Task<HttpResponseMessage> DeleteSkill(Skill skill)
		{
			 var url = Constants.SkillUrl + skill.SkillId.ToString();
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

		public static async Task<Technology> GetTechnology(int id)
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

		public static async Task<Unit> GetUnit(int id)
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

		public static async Task<HttpResponseMessage> CreateUnitLevel(UnitLevel unitLevel)
		{
			string jsonChore = JsonConvert.SerializeObject(unitLevel);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UnitLevelUrl,httpContent);
			return result;
		}

		public static async Task<UnitLevel> GetUnitLevel(int id)
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

	}
}