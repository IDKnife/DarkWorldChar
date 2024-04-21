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

		public void Validate(Character character)
		{
			ValidateStepOne(character.Concept);
			ValidateStepTwo(character.Attributes);
		}

		private void ValidateStepOne(Concept concept)
		{
			if (m_entityServices[nameof(concept.Auspice)](concept.Auspice) == null)
			{
				throw new GlobalApplicationException(
					$"There isn't auspice - {concept.Auspice}",
					StatusCodes.Status400BadRequest);
			}
			if (m_entityServices[nameof(concept.Breed)](concept.Breed) == null)
			{
				throw new GlobalApplicationException(
					$"There isn't breed - {concept.Breed}",
					StatusCodes.Status400BadRequest);
			}
			if (m_entityServices[nameof(concept.Tribe)](concept.Tribe) == null)
			{
				throw new GlobalApplicationException(
					$"There isn't tribe - {concept.Tribe}",
					StatusCodes.Status400BadRequest);
			}
			if (m_entityServices[nameof(concept.Nature)](concept.Nature) == null)
			{
				throw new GlobalApplicationException(
					$"There isn't nature - {concept.Nature}",
					StatusCodes.Status400BadRequest);
			}
		}

		private void ValidateStepTwo(Attributes attributes)
		{
			if (attributes.Strength < 1
				|| attributes.Dexterity < 1
				|| attributes.Stamina < 1
				|| attributes.Charisma < 1
				|| attributes.Manipulation < 1
				|| attributes.Appearance < 1
				|| attributes.Perception < 1
				|| attributes.Intelligence < 1
				|| attributes.Wits < 1)
			{
				throw new GlobalApplicationException(
					$"There can't be attribute with less than one point",
					StatusCodes.Status400BadRequest);
			}

			int physicalScore = attributes.Strength + attributes.Dexterity + attributes.Stamina - 3;
			int socialScore = attributes.Charisma + attributes.Manipulation + attributes.Appearance - 3;
			int mentalScore = attributes.Perception + attributes.Intelligence + attributes.Wits - 3;
			int totalScore = physicalScore + socialScore + mentalScore;

			if (totalScore < 15)
			{
				throw new GlobalApplicationException(
					$"Not all available points are spent",
					StatusCodes.Status400BadRequest);
			}
		}
	}
}
