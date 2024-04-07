using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarkWorldChar.Model.Common;
using DarkWorldChar.Model.MainModel;
using DarkWorldChar.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DarkWorldChar.Services.Interfaces
{
	internal class LocalizationService : ILocalizationService
	{
		private readonly ILocalizationRepository m_repository;
		private readonly List<Func<string, Entity>> m_entityServices;

		public LocalizationService(
			ILocalizationRepository repository,
			IEntityService<Auspice> auspiceService,
			IEntityService<Breed> breedService,
			IEntityService<Tribe> tribeService)
		{
			m_repository = repository;
			m_entityServices = new List<Func<string, Entity>>()
			{
				(string code) => auspiceService.ReadEntity(code).Result,
				(string code) => breedService.ReadEntity(code).Result,
				(string code) => tribeService.ReadEntity(code).Result,
			};
		}

		public async Task CreateEntity(EntityLocalized entity)
		{
			var existingEntity = await ReadEntity(entity.Code, entity.Language);
			if (existingEntity != null)
			{
				throw new GlobalApplicationException(
					$"There is already localization for {entity.Language} for entity with code - {entity.Code}",
					StatusCodes.Status400BadRequest);
			}

			if (!m_entityServices.Any(r => r(entity.Code) != null))
			{
				throw new GlobalApplicationException(
					$"There is no entity with code - {entity.Code}",
					StatusCodes.Status400BadRequest);
			}

			await m_repository.CreateEntity(entity);
		}

		public async Task DeleteEntity(string code, string language)
		{
			var existingEntity = await ReadEntity(code, language);
			if (existingEntity == null)
			{
				throw new GlobalApplicationException(
					$"There is no localization for {language} for entity with code - {code}",
					StatusCodes.Status400BadRequest);
			}
			await m_repository.DeleteEntity(code, language);
		}

		public async Task<EntityLocalized> ReadEntity(string code, string language)
		{
			return await m_repository.ReadEntity(code, language);
		}

		public async Task UpdateEntity(EntityLocalized entity)
		{
			var existingEntity = await ReadEntity(entity.Code, entity.Language);
			if (existingEntity == null)
			{
				throw new GlobalApplicationException(
					$"There is no localization for {entity.Language} for entity with code - {entity.Code}",
					StatusCodes.Status400BadRequest);
			}
			await m_repository.UpdateEntity(entity);
		}
	}
}
