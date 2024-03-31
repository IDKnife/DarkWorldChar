using System.Threading.Tasks;
using DarkWorldChar.Model.MainModel;
using DarkWorldChar.Repositories.Interfaces;
using MongoDB.Driver;

namespace DarkWorldChar.Repositories.Implementations
{
	internal class LocalizationRepository : MongoRepository<EntityLocalized>, ILocalizationRepository
	{
		public LocalizationRepository(IMongoDatabase database) : base(database)
		{
		}

		public async Task CreateEntity(EntityLocalized entity)
		{
			await ListOfEntities.InsertOneAsync(entity);
		}

		public async Task DeleteEntity(string code, string language)
		{
			await ListOfEntities.DeleteOneAsync(FilterCombined(FilterCode(code), FilterLanguage(language)));
		}

		public async Task<EntityLocalized> ReadEntity(string code, string language)
		{
			return await ListOfEntities.Find(FilterCombined(FilterCode(code), FilterLanguage(language))).FirstOrDefaultAsync();
		}

		public async Task UpdateEntity(EntityLocalized entity)
		{
			await ListOfEntities.ReplaceOneAsync(FilterCombined(FilterCode(entity.Code), FilterLanguage(entity.Language)), entity);
		}

		private FilterDefinition<EntityLocalized> FilterLanguage(string language)
		{
			return Builders<EntityLocalized>.Filter.Eq("Language", language);
		}
	}
}
