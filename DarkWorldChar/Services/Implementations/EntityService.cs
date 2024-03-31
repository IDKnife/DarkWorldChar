using System.Collections.Generic;
using System.Threading.Tasks;
using DarkWorldChar.Model.Common;
using DarkWorldChar.Model.MainModel;
using DarkWorldChar.Repositories.Interfaces;
using DarkWorldChar.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DarkWorldChar.Services.Implementations
{
	internal class EntityService<T> : IEntityService<T>
		where T : Entity
	{
		private readonly IRepository<T> m_repository;

		public EntityService(IRepository<T> repository)
		{
			m_repository = repository;
		}

		public async Task CreateEntities(HashSet<T> entities)
		{
			foreach (var entity in entities)
			{
				await CreateEntity(entity);
			}
		}

		public async Task CreateEntity(T entity)
		{
			var existingEntity = await ReadEntity(entity.Code);
			if (existingEntity != null)
			{
				throw new GlobalApplicationException(
					$"There is already entity with code - {entity.Code}",
					StatusCodes.Status400BadRequest);
			}
			await m_repository.CreateEntity(entity);
		}

		public async Task DeleteEntities(HashSet<string> codes)
		{
			foreach (var code in codes)
			{
				await DeleteEntity(code);
			}
		}

		public async Task DeleteEntity(string code)
		{
			await m_repository.DeleteEntity(code);
		}

		public async Task<List<T>> ReadEntities()
		{
			return await m_repository.ReadEntities();
		}

		public async Task<T> ReadEntity(string code)
		{
			return await m_repository.ReadEntity(code);
		}

		public async Task UpdateEntity(T entity)
		{
			var existingEntity = await ReadEntity(entity.Code);
			if (existingEntity == null)
			{
				throw new GlobalApplicationException(
					$"There is no entity with code - {entity.Code}",
					StatusCodes.Status400BadRequest);
			}
			await m_repository.UpdateEntity(entity);
		}
	}
}
