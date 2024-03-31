using System.Collections.Generic;
using System.Threading.Tasks;
using DarkWorldChar.Model.MainModel;
using DarkWorldChar.Repositories.Interfaces;
using MongoDB.Driver;

namespace DarkWorldChar.Repositories.Implementations
{
	internal class EntityRepository<T> : MongoRepository<T>, IRepository<T>
		where T : Entity, new()
	{
		public EntityRepository(IMongoDatabase database) : base(database)
		{
		}

		public async Task CreateEntity(T entity)
		{
			await ListOfEntities.InsertOneAsync(entity);
		}

		public async Task DeleteEntity(string code)
		{
			await ListOfEntities.DeleteOneAsync(FilterCode(code));
		}

		public async Task<List<T>> ReadEntities()
		{
			return await ListOfEntities.Find(FilterEmpty()).ToListAsync();
		}

		public async Task<T> ReadEntity(string code)
		{
			return await ListOfEntities.Find(FilterCode(code)).FirstOrDefaultAsync();
		}

		public async Task UpdateEntity(T entity)
		{
			await ListOfEntities.ReplaceOneAsync(FilterCode(entity.Code), entity);
		}
	}
}
