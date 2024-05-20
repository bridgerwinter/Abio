using Abio.Library.DatabaseModels;
using Newtonsoft.Json;
using System.Text;
using Abio.Library.Services;
using Attribute = Abio.Library.DatabaseModels.Attribute;

namespace Abio.Library.Services
{	
	public partial class ApiService
	{
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateMarket(Market market)
		{
			string jsonChore = JsonConvert.SerializeObject(market);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.MarketUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<Market> GetMarket(Guid id)
		{
			var url = $"{Constants.MarketUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Market>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<Market>> GetAllMarkets()
		{
			var url = Constants.MarketUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<Market>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateMarket(Market market)
		{
			var url = $"{Constants.MarketUrl}/{market.MarketId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(market);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteMarket(Market market)
		{
			var url = $"{Constants.MarketUrl}/{market.MarketId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(market);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateMarketListing(MarketListing marketlisting)
		{
			string jsonChore = JsonConvert.SerializeObject(marketlisting);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.MarketListingUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<MarketListing> GetMarketListing(Guid id)
		{
			var url = $"{Constants.MarketListingUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<MarketListing>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<MarketListing>> GetAllMarketListings()
		{
			var url = Constants.MarketListingUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<MarketListing>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateMarketListing(MarketListing marketlisting)
		{
			var url = $"{Constants.MarketListingUrl}/{marketlisting.MarketListingId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(marketlisting);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteMarketListing(MarketListing marketlisting)
		{
			var url = $"{Constants.MarketListingUrl}/{marketlisting.MarketListingId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(marketlisting);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateAttribute(Attribute attribute)
		{
			string jsonChore = JsonConvert.SerializeObject(attribute);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.AttributeUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<Attribute> GetAttribute(int id)
		{
			var url = $"{Constants.AttributeUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Attribute>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<Attribute>> GetAllAttributes()
		{
			var url = Constants.AttributeUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<Attribute>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateAttribute(Attribute attribute)
		{
			var url = $"{Constants.AttributeUrl}/{attribute.AttributeId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(attribute);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteAttribute(Attribute attribute)
		{
			var url = $"{Constants.AttributeUrl}/{attribute.AttributeId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(attribute);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateBodyPart(BodyPart bodypart)
		{
			string jsonChore = JsonConvert.SerializeObject(bodypart);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.BodyPartUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<BodyPart> GetBodyPart(int id)
		{
			var url = $"{Constants.BodyPartUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<BodyPart>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<BodyPart>> GetAllBodyParts()
		{
			var url = Constants.BodyPartUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<BodyPart>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateBodyPart(BodyPart bodypart)
		{
			var url = $"{Constants.BodyPartUrl}/{bodypart.BodyPartId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(bodypart);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteBodyPart(BodyPart bodypart)
		{
			var url = $"{Constants.BodyPartUrl}/{bodypart.BodyPartId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(bodypart);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateBuilding(Building building)
		{
			string jsonChore = JsonConvert.SerializeObject(building);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.BuildingUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<Building> GetBuilding(int id)
		{
			var url = $"{Constants.BuildingUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Building>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<Building>> GetAllBuildings()
		{
			var url = Constants.BuildingUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<Building>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateBuilding(Building building)
		{
			var url = $"{Constants.BuildingUrl}/{building.BuildingId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(building);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteBuilding(Building building)
		{
			var url = $"{Constants.BuildingUrl}/{building.BuildingId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(building);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateBuildingLevel(BuildingLevel buildinglevel)
		{
			string jsonChore = JsonConvert.SerializeObject(buildinglevel);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.BuildingLevelUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<BuildingLevel> GetBuildingLevel(int id)
		{
			var url = $"{Constants.BuildingLevelUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<BuildingLevel>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<BuildingLevel>> GetAllBuildingLevels()
		{
			var url = Constants.BuildingLevelUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<BuildingLevel>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateBuildingLevel(BuildingLevel buildinglevel)
		{
			var url = $"{Constants.BuildingLevelUrl}/{buildinglevel.BuildingLevelId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(buildinglevel);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteBuildingLevel(BuildingLevel buildinglevel)
		{
			var url = $"{Constants.BuildingLevelUrl}/{buildinglevel.BuildingLevelId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(buildinglevel);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateEmotion(Emotion emotion)
		{
			string jsonChore = JsonConvert.SerializeObject(emotion);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.EmotionUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<Emotion> GetEmotion(int id)
		{
			var url = $"{Constants.EmotionUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Emotion>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<Emotion>> GetAllEmotions()
		{
			var url = Constants.EmotionUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<Emotion>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateEmotion(Emotion emotion)
		{
			var url = $"{Constants.EmotionUrl}/{emotion.EmotionId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(emotion);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteEmotion(Emotion emotion)
		{
			var url = $"{Constants.EmotionUrl}/{emotion.EmotionId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(emotion);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateFaction(Faction faction)
		{
			string jsonChore = JsonConvert.SerializeObject(faction);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.FactionUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<Faction> GetFaction(int id)
		{
			var url = $"{Constants.FactionUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Faction>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<Faction>> GetAllFactions()
		{
			var url = Constants.FactionUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<Faction>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateFaction(Faction faction)
		{
			var url = $"{Constants.FactionUrl}/{faction.FactionId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(faction);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteFaction(Faction faction)
		{
			var url = $"{Constants.FactionUrl}/{faction.FactionId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(faction);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateFeat(Feat feat)
		{
			string jsonChore = JsonConvert.SerializeObject(feat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.FeatUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<Feat> GetFeat(int id)
		{
			var url = $"{Constants.FeatUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Feat>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<Feat>> GetAllFeats()
		{
			var url = Constants.FeatUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<Feat>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateFeat(Feat feat)
		{
			var url = $"{Constants.FeatUrl}/{feat.FeatId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(feat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteFeat(Feat feat)
		{
			var url = $"{Constants.FeatUrl}/{feat.FeatId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(feat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateItem(Item item)
		{
			string jsonChore = JsonConvert.SerializeObject(item);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ItemUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<Item> GetItem(int id)
		{
			var url = $"{Constants.ItemUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Item>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<Item>> GetAllItems()
		{
			var url = Constants.ItemUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<Item>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateItem(Item item)
		{
			var url = $"{Constants.ItemUrl}/{item.ItemId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(item);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteItem(Item item)
		{
			var url = $"{Constants.ItemUrl}/{item.ItemId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(item);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreatePersonalityTrait(PersonalityTrait personalitytrait)
		{
			string jsonChore = JsonConvert.SerializeObject(personalitytrait);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.PersonalityTraitUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<PersonalityTrait> GetPersonalityTrait(int id)
		{
			var url = $"{Constants.PersonalityTraitUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<PersonalityTrait>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<PersonalityTrait>> GetAllPersonalityTraits()
		{
			var url = Constants.PersonalityTraitUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<PersonalityTrait>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdatePersonalityTrait(PersonalityTrait personalitytrait)
		{
			var url = $"{Constants.PersonalityTraitUrl}/{personalitytrait.PersonalityTraitId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(personalitytrait);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeletePersonalityTrait(PersonalityTrait personalitytrait)
		{
			var url = $"{Constants.PersonalityTraitUrl}/{personalitytrait.PersonalityTraitId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(personalitytrait);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateResource(Resource resource)
		{
			string jsonChore = JsonConvert.SerializeObject(resource);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ResourceUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<Resource> GetResource(int id)
		{
			var url = $"{Constants.ResourceUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Resource>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<Resource>> GetAllResources()
		{
			var url = Constants.ResourceUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<Resource>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateResource(Resource resource)
		{
			var url = $"{Constants.ResourceUrl}/{resource.ResourceId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(resource);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteResource(Resource resource)
		{
			var url = $"{Constants.ResourceUrl}/{resource.ResourceId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(resource);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateSkill(Skill skill)
		{
			string jsonChore = JsonConvert.SerializeObject(skill);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.SkillUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<Skill> GetSkill(int id)
		{
			var url = $"{Constants.SkillUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Skill>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<Skill>> GetAllSkills()
		{
			var url = Constants.SkillUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<Skill>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateSkill(Skill skill)
		{
			var url = $"{Constants.SkillUrl}/{skill.SkillId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(skill);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteSkill(Skill skill)
		{
			var url = $"{Constants.SkillUrl}/{skill.SkillId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(skill);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateTechnology(Technology technology)
		{
			string jsonChore = JsonConvert.SerializeObject(technology);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.TechnologyUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<Technology> GetTechnology(int id)
		{
			var url = $"{Constants.TechnologyUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Technology>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<Technology>> GetAllTechnologys()
		{
			var url = Constants.TechnologyUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<Technology>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateTechnology(Technology technology)
		{
			var url = $"{Constants.TechnologyUrl}/{technology.TechnologyId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(technology);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteTechnology(Technology technology)
		{
			var url = $"{Constants.TechnologyUrl}/{technology.TechnologyId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(technology);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateUnit(Unit unit)
		{
			string jsonChore = JsonConvert.SerializeObject(unit);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UnitUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<Unit> GetUnit(int id)
		{
			var url = $"{Constants.UnitUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Unit>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<Unit>> GetAllUnits()
		{
			var url = Constants.UnitUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<Unit>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateUnit(Unit unit)
		{
			var url = $"{Constants.UnitUrl}/{unit.UnitId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(unit);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteUnit(Unit unit)
		{
			var url = $"{Constants.UnitUrl}/{unit.UnitId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(unit);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateUnitLevel(UnitLevel unitlevel)
		{
			string jsonChore = JsonConvert.SerializeObject(unitlevel);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UnitLevelUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<UnitLevel> GetUnitLevel(int id)
		{
			var url = $"{Constants.UnitLevelUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<UnitLevel>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<UnitLevel>> GetAllUnitLevels()
		{
			var url = Constants.UnitLevelUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<UnitLevel>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateUnitLevel(UnitLevel unitlevel)
		{
			var url = $"{Constants.UnitLevelUrl}/{unitlevel.UnitLevelId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(unitlevel);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteUnitLevel(UnitLevel unitlevel)
		{
			var url = $"{Constants.UnitLevelUrl}/{unitlevel.UnitLevelId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(unitlevel);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateConstructedBuilding(ConstructedBuilding constructedbuilding)
		{
			string jsonChore = JsonConvert.SerializeObject(constructedbuilding);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ConstructedBuildingUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<ConstructedBuilding> GetConstructedBuilding(Guid id)
		{
			var url = $"{Constants.ConstructedBuildingUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<ConstructedBuilding>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<ConstructedBuilding>> GetAllConstructedBuildings()
		{
			var url = Constants.ConstructedBuildingUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<ConstructedBuilding>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateConstructedBuilding(ConstructedBuilding constructedbuilding)
		{
			var url = $"{Constants.ConstructedBuildingUrl}/{constructedbuilding.ConstructedBuildingId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(constructedbuilding);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteConstructedBuilding(ConstructedBuilding constructedbuilding)
		{
			var url = $"{Constants.ConstructedBuildingUrl}/{constructedbuilding.ConstructedBuildingId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(constructedbuilding);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateFriend(Friend friend)
		{
			string jsonChore = JsonConvert.SerializeObject(friend);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.FriendUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<Friend> GetFriend(Guid id)
		{
			var url = $"{Constants.FriendUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Friend>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<Friend>> GetAllFriends()
		{
			var url = Constants.FriendUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<Friend>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateFriend(Friend friend)
		{
			var url = $"{Constants.FriendUrl}/{friend.UserId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(friend);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteFriend(Friend friend)
		{
			var url = $"{Constants.FriendUrl}/{friend.UserId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(friend);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateHiredLeader(HiredLeader hiredleader)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredleader);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredLeaderUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<HiredLeader> GetHiredLeader(Guid id)
		{
			var url = $"{Constants.HiredLeaderUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredLeader>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<HiredLeader>> GetAllHiredLeaders()
		{
			var url = Constants.HiredLeaderUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredLeader>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateHiredLeader(HiredLeader hiredleader)
		{
			var url = $"{Constants.HiredLeaderUrl}/{hiredleader.HiredLeaderId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredleader);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteHiredLeader(HiredLeader hiredleader)
		{
			var url = $"{Constants.HiredLeaderUrl}/{hiredleader.HiredLeaderId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredleader);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateHiredLeaderStat(HiredLeaderStat hiredleaderstat)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredleaderstat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredLeaderStatUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<HiredLeaderStat> GetHiredLeaderStat(Guid id)
		{
			var url = $"{Constants.HiredLeaderStatUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredLeaderStat>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<HiredLeaderStat>> GetAllHiredLeaderStats()
		{
			var url = Constants.HiredLeaderStatUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredLeaderStat>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateHiredLeaderStat(HiredLeaderStat hiredleaderstat)
		{
			var url = $"{Constants.HiredLeaderStatUrl}/{hiredleaderstat.HiredLeaderStatId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredleaderstat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteHiredLeaderStat(HiredLeaderStat hiredleaderstat)
		{
			var url = $"{Constants.HiredLeaderStatUrl}/{hiredleaderstat.HiredLeaderStatId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredleaderstat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateHiredUnit(HiredUnit hiredunit)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredunit);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<HiredUnit> GetHiredUnit(Guid id)
		{
			var url = $"{Constants.HiredUnitUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnit>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<HiredUnit>> GetAllHiredUnits()
		{
			var url = Constants.HiredUnitUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnit>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateHiredUnit(HiredUnit hiredunit)
		{
			var url = $"{Constants.HiredUnitUrl}/{hiredunit.HiredUnitId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunit);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteHiredUnit(HiredUnit hiredunit)
		{
			var url = $"{Constants.HiredUnitUrl}/{hiredunit.HiredUnitId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunit);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateHiredUnitStat(HiredUnitStat hiredunitstat)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredunitstat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitStatUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<HiredUnitStat> GetHiredUnitStat(Guid id)
		{
			var url = $"{Constants.HiredUnitStatUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnitStat>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<HiredUnitStat>> GetAllHiredUnitStats()
		{
			var url = Constants.HiredUnitStatUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnitStat>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateHiredUnitStat(HiredUnitStat hiredunitstat)
		{
			var url = $"{Constants.HiredUnitStatUrl}/{hiredunitstat.HiredUnitStatId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunitstat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteHiredUnitStat(HiredUnitStat hiredunitstat)
		{
			var url = $"{Constants.HiredUnitStatUrl}/{hiredunitstat.HiredUnitStatId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunitstat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateHiredUnitStatBody(HiredUnitStatBody hiredunitstatbody)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatbody);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitStatBodyUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<HiredUnitStatBody> GetHiredUnitStatBody(Guid id)
		{
			var url = $"{Constants.HiredUnitStatBodyUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnitStatBody>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<HiredUnitStatBody>> GetAllHiredUnitStatBodys()
		{
			var url = Constants.HiredUnitStatBodyUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnitStatBody>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateHiredUnitStatBody(HiredUnitStatBody hiredunitstatbody)
		{
			var url = $"{Constants.HiredUnitStatBodyUrl}/{hiredunitstatbody.HiredUnitStatBodyId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatbody);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteHiredUnitStatBody(HiredUnitStatBody hiredunitstatbody)
		{
			var url = $"{Constants.HiredUnitStatBodyUrl}/{hiredunitstatbody.HiredUnitStatBodyId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatbody);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateHiredUnitStatCivil(HiredUnitStatCivil hiredunitstatcivil)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatcivil);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitStatCivilUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<HiredUnitStatCivil> GetHiredUnitStatCivil(Guid id)
		{
			var url = $"{Constants.HiredUnitStatCivilUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnitStatCivil>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<HiredUnitStatCivil>> GetAllHiredUnitStatCivils()
		{
			var url = Constants.HiredUnitStatCivilUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnitStatCivil>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateHiredUnitStatCivil(HiredUnitStatCivil hiredunitstatcivil)
		{
			var url = $"{Constants.HiredUnitStatCivilUrl}/{hiredunitstatcivil.HiredUnitStatCivilId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatcivil);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteHiredUnitStatCivil(HiredUnitStatCivil hiredunitstatcivil)
		{
			var url = $"{Constants.HiredUnitStatCivilUrl}/{hiredunitstatcivil.HiredUnitStatCivilId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatcivil);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateHiredUnitStatCombat(HiredUnitStatCombat hiredunitstatcombat)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatcombat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitStatCombatUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<HiredUnitStatCombat> GetHiredUnitStatCombat(Guid id)
		{
			var url = $"{Constants.HiredUnitStatCombatUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnitStatCombat>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<HiredUnitStatCombat>> GetAllHiredUnitStatCombats()
		{
			var url = Constants.HiredUnitStatCombatUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnitStatCombat>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateHiredUnitStatCombat(HiredUnitStatCombat hiredunitstatcombat)
		{
			var url = $"{Constants.HiredUnitStatCombatUrl}/{hiredunitstatcombat.HiredUnitStatCombatId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatcombat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteHiredUnitStatCombat(HiredUnitStatCombat hiredunitstatcombat)
		{
			var url = $"{Constants.HiredUnitStatCombatUrl}/{hiredunitstatcombat.HiredUnitStatCombatId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatcombat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateHiredUnitStatEmotion(HiredUnitStatEmotion hiredunitstatemotion)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatemotion);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitStatEmotionUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<HiredUnitStatEmotion> GetHiredUnitStatEmotion(Guid id)
		{
			var url = $"{Constants.HiredUnitStatEmotionUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnitStatEmotion>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<HiredUnitStatEmotion>> GetAllHiredUnitStatEmotions()
		{
			var url = Constants.HiredUnitStatEmotionUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnitStatEmotion>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateHiredUnitStatEmotion(HiredUnitStatEmotion hiredunitstatemotion)
		{
			var url = $"{Constants.HiredUnitStatEmotionUrl}/{hiredunitstatemotion.HiredUnitStatEmotionId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatemotion);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteHiredUnitStatEmotion(HiredUnitStatEmotion hiredunitstatemotion)
		{
			var url = $"{Constants.HiredUnitStatEmotionUrl}/{hiredunitstatemotion.HiredUnitStatEmotionId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatemotion);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateHiredUnitStatFeat(HiredUnitStatFeat hiredunitstatfeat)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatfeat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitStatFeatUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<HiredUnitStatFeat> GetHiredUnitStatFeat(Guid id)
		{
			var url = $"{Constants.HiredUnitStatFeatUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnitStatFeat>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<HiredUnitStatFeat>> GetAllHiredUnitStatFeats()
		{
			var url = Constants.HiredUnitStatFeatUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnitStatFeat>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateHiredUnitStatFeat(HiredUnitStatFeat hiredunitstatfeat)
		{
			var url = $"{Constants.HiredUnitStatFeatUrl}/{hiredunitstatfeat.HiredUnitStatFeatId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatfeat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteHiredUnitStatFeat(HiredUnitStatFeat hiredunitstatfeat)
		{
			var url = $"{Constants.HiredUnitStatFeatUrl}/{hiredunitstatfeat.HiredUnitStatFeatId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatfeat);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateHiredUnitStatMagic(HiredUnitStatMagic hiredunitstatmagic)
		{
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatmagic);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.HiredUnitStatMagicUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<HiredUnitStatMagic> GetHiredUnitStatMagic(Guid id)
		{
			var url = $"{Constants.HiredUnitStatMagicUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<HiredUnitStatMagic>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<HiredUnitStatMagic>> GetAllHiredUnitStatMagics()
		{
			var url = Constants.HiredUnitStatMagicUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<HiredUnitStatMagic>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateHiredUnitStatMagic(HiredUnitStatMagic hiredunitstatmagic)
		{
			var url = $"{Constants.HiredUnitStatMagicUrl}/{hiredunitstatmagic.HiredUnitStatMagicId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatmagic);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteHiredUnitStatMagic(HiredUnitStatMagic hiredunitstatmagic)
		{
			var url = $"{Constants.HiredUnitStatMagicUrl}/{hiredunitstatmagic.HiredUnitStatMagicId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(hiredunitstatmagic);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateItemInventory(ItemInventory iteminventory)
		{
			string jsonChore = JsonConvert.SerializeObject(iteminventory);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ItemInventoryUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<ItemInventory> GetItemInventory(Guid id)
		{
			var url = $"{Constants.ItemInventoryUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<ItemInventory>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<ItemInventory>> GetAllItemInventorys()
		{
			var url = Constants.ItemInventoryUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<ItemInventory>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateItemInventory(ItemInventory iteminventory)
		{
			var url = $"{Constants.ItemInventoryUrl}/{iteminventory.ItemInventoryId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(iteminventory);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteItemInventory(ItemInventory iteminventory)
		{
			var url = $"{Constants.ItemInventoryUrl}/{iteminventory.ItemInventoryId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(iteminventory);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreatePlayer(Player player)
		{
			string jsonChore = JsonConvert.SerializeObject(player);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.PlayerUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<Player> GetPlayer(Guid id)
		{
			var url = $"{Constants.PlayerUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<Player>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<Player>> GetAllPlayers()
		{
			var url = Constants.PlayerUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<Player>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdatePlayer(Player player)
		{
			var url = $"{Constants.PlayerUrl}/{player.UserId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(player);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeletePlayer(Player player)
		{
			var url = $"{Constants.PlayerUrl}/{player.UserId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(player);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateResearchedTechnology(ResearchedTechnology researchedtechnology)
		{
			string jsonChore = JsonConvert.SerializeObject(researchedtechnology);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ResearchedTechnologyUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<ResearchedTechnology> GetResearchedTechnology(Guid id)
		{
			var url = $"{Constants.ResearchedTechnologyUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<ResearchedTechnology>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<ResearchedTechnology>> GetAllResearchedTechnologys()
		{
			var url = Constants.ResearchedTechnologyUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<ResearchedTechnology>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateResearchedTechnology(ResearchedTechnology researchedtechnology)
		{
			var url = $"{Constants.ResearchedTechnologyUrl}/{researchedtechnology.ResearchedTechnologyId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(researchedtechnology);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteResearchedTechnology(ResearchedTechnology researchedtechnology)
		{
			var url = $"{Constants.ResearchedTechnologyUrl}/{researchedtechnology.ResearchedTechnologyId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(researchedtechnology);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateResourceGain(ResourceGain resourcegain)
		{
			string jsonChore = JsonConvert.SerializeObject(resourcegain);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ResourceGainUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<ResourceGain> GetResourceGain(Guid id)
		{
			var url = $"{Constants.ResourceGainUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<ResourceGain>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<ResourceGain>> GetAllResourceGains()
		{
			var url = Constants.ResourceGainUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<ResourceGain>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateResourceGain(ResourceGain resourcegain)
		{
			var url = $"{Constants.ResourceGainUrl}/{resourcegain.ResourceGainId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(resourcegain);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteResourceGain(ResourceGain resourcegain)
		{
			var url = $"{Constants.ResourceGainUrl}/{resourcegain.ResourceGainId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(resourcegain);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateResourceInventory(ResourceInventory resourceinventory)
		{
			string jsonChore = JsonConvert.SerializeObject(resourceinventory);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.ResourceInventoryUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<ResourceInventory> GetResourceInventory(Guid id)
		{
			var url = $"{Constants.ResourceInventoryUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<ResourceInventory>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<ResourceInventory>> GetAllResourceInventorys()
		{
			var url = Constants.ResourceInventoryUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<ResourceInventory>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateResourceInventory(ResourceInventory resourceinventory)
		{
			var url = $"{Constants.ResourceInventoryUrl}/{resourceinventory.ResourceInventoryId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(resourceinventory);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteResourceInventory(ResourceInventory resourceinventory)
		{
			var url = $"{Constants.ResourceInventoryUrl}/{resourceinventory.ResourceInventoryId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(resourceinventory);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateUserCity(UserCity usercity)
		{
			string jsonChore = JsonConvert.SerializeObject(usercity);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UserCityUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<UserCity> GetUserCity(Guid id)
		{
			var url = $"{Constants.UserCityUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<UserCity>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<UserCity>> GetAllUserCitys()
		{
			var url = Constants.UserCityUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<UserCity>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateUserCity(UserCity usercity)
		{
			var url = $"{Constants.UserCityUrl}/{usercity.UserCityId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(usercity);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteUserCity(UserCity usercity)
		{
			var url = $"{Constants.UserCityUrl}/{usercity.UserCityId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(usercity);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateUserCityLeader(UserCityLeader usercityleader)
		{
			string jsonChore = JsonConvert.SerializeObject(usercityleader);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UserCityLeaderUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<UserCityLeader> GetUserCityLeader(Guid id)
		{
			var url = $"{Constants.UserCityLeaderUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<UserCityLeader>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<UserCityLeader>> GetAllUserCityLeaders()
		{
			var url = Constants.UserCityLeaderUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<UserCityLeader>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateUserCityLeader(UserCityLeader usercityleader)
		{
			var url = $"{Constants.UserCityLeaderUrl}/{usercityleader.UserCityLeaderId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(usercityleader);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteUserCityLeader(UserCityLeader usercityleader)
		{
			var url = $"{Constants.UserCityLeaderUrl}/{usercityleader.UserCityLeaderId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(usercityleader);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
		// POST (CREATE)
		public static async Task<HttpResponseMessage> CreateUser(User user)
		{
			string jsonChore = JsonConvert.SerializeObject(user);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.UserUrl, httpContent);
			return result;
		}

		// GET
		public static async Task<User> GetUser(Guid id)
		{
			var url = $"{Constants.UserUrl}/{id.ToString()}";
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<User>(result);
			return deserializedResult;
		}

		// GET ALL
		public static async Task<List<User>> GetAllUsers()
		{
			var url = Constants.UserUrl.ToString();
			string result = await Constants.GetClient().GetStringAsync(url);
			var deserializedResult = JsonConvert.DeserializeObject<List<User>>(result);
			return deserializedResult;
		}

		// PUT (UPDATE)
		public static async Task<HttpResponseMessage> UpdateUser(User user)
		{
			var url = $"{Constants.UserUrl}/{user.UserId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(user);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().PutAsync(url,httpContent);
			return result;
		}

		// DELETE (UPDATE)
		public static async Task<HttpResponseMessage> DeleteUser(User user)
		{
			var url = $"{Constants.UserUrl}/{user.UserId.ToString()}";
			string jsonChore = JsonConvert.SerializeObject(user);
			StringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, "application/json");
			HttpResponseMessage result = await Constants.GetClient().DeleteAsync(url);
			return result;
		}
		
		
	}
}


