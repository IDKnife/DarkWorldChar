using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DarkWorldChar.Backend.Helpers;
using DarkWorldChar.Model.Common;
using DarkWorldChar.Model.MainModel;
using DarkWorldChar.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DarkWorldChar.Backend.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[EnableCors(PolicyName = "DefaultPolicy")]
	public class BreedController : ControllerBase
	{
		private readonly IEntityService<Breed> m_entityService;
		private readonly ILocalizationService m_localizationService;

		public BreedController(IEntityService<Breed> entityService, ILocalizationService localizationService)
		{
			m_entityService = entityService;
			m_localizationService = localizationService;
		}

		[HttpPost]
		[Route("AddBreed")]
		[ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(GlobalExceptionDetails), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddBreed([FromBody] Breed breed)
		{
			await m_entityService.CreateEntity(breed);
			return ActionResultHelper.GetResult(StatusCodes.Status201Created);
		}

		[HttpGet]
		[Route("GetBreed/{code}")]
		[ProducesResponseType(typeof(Breed), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(GlobalExceptionDetails), StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetBreed([FromRoute] string code)
		{
			var result = await m_entityService.ReadEntity(code);
			if (result == null)
			{
				throw new GlobalApplicationException(
					$"There is no entity with code - {code}",
					StatusCodes.Status404NotFound);
			}
			return ActionResultHelper.GetResult(StatusCodes.Status200OK, result);
		}

		[HttpGet]
		[Route("GetBreedLocalized/{code}")]
		[ProducesResponseType(typeof(EntityLocalized), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(GlobalExceptionDetails), StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetBreedLocalized(
			[FromRoute] string code,
			[FromQuery][Required] string language)
		{
			var result = await m_localizationService.ReadEntity(code, language);
			if (result == null)
			{
				throw new GlobalApplicationException(
					$"There is no entity localization for code - {code} and language - {language}",
					StatusCodes.Status404NotFound);
			}
			return ActionResultHelper.GetResult(StatusCodes.Status200OK, result);
		}
	}
}
