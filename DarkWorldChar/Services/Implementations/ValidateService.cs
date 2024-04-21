using System;
using System.Collections.Generic;
using DarkWorldChar.Model.Common;
using DarkWorldChar.Model.MainModel;
using DarkWorldChar.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DarkWorldChar.Services.Implementations
{
	internal class ValidateService : IValidateService
	{
		private Dictionary<string, Func<string, Entity>> m_entityServices;

		public ValidateService(
			IEntityService<Auspice> auspiceService,
			IEntityService<Breed> breedService,
			IEntityService<Tribe> tribeService,
			IEntityService<Nature> natureService)
		{
			m_entityServices = new Dictionary<string, Func<string, Entity>>()
			{
				[nameof(Auspice)] = (string code) => auspiceService.ReadEntity(code).Result,
				[nameof(Breed)] = (string code) => breedService.ReadEntity(code).Result,
				[nameof(Tribe)] = (string code) => tribeService.ReadEntity(code).Result,
				[nameof(Nature)] = (string code) => natureService.ReadEntity(code).Result,
			};
		}

		public void Validate(Character characterInput)
		{
			ValidateStepOne(characterInput);
		}

		private void ValidateStepOne(Character characterInput)
		{
			if (m_entityServices[nameof(characterInput.Auspice)](characterInput.Auspice) == null)
			{
				throw new GlobalApplicationException(
					$"There isn't auspice - {characterInput.Auspice}",
					StatusCodes.Status400BadRequest);
			}
			if (m_entityServices[nameof(characterInput.Breed)](characterInput.Breed) == null)
			{
				throw new GlobalApplicationException(
					$"There isn't breed - {characterInput.Breed}",
					StatusCodes.Status400BadRequest);
			}
			if (m_entityServices[nameof(characterInput.Tribe)](characterInput.Tribe) == null)
			{
				throw new GlobalApplicationException(
					$"There isn't tribe - {characterInput.Tribe}",
					StatusCodes.Status400BadRequest);
			}
			if (m_entityServices[nameof(characterInput.Nature)](characterInput.Nature) == null)
			{
				throw new GlobalApplicationException(
					$"There isn't nature - {characterInput.Nature}",
					StatusCodes.Status400BadRequest);
			}
		}
	}
}
