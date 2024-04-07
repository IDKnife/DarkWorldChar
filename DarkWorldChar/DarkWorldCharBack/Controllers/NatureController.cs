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
	public class NatureController : ControllerBase
	{
		private readonly IEntityService<Nature> m_entityService;
		private readonly ILocalizationService m_localizationService;

		public NatureController(IEntityService<Nature> entityService, ILocalizationService localizationService)
		{
			m_entityService = entityService;
			m_localizationService = localizationService;
		}

		[HttpPost]
		[Route("AddNature")]
		[ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(GlobalExceptionDetails), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddNature([FromBody] Nature nature)
		{
			await m_entityService.CreateEntity(nature);
			return ActionResultHelper.GetResult(StatusCodes.Status201Created);
		}

		[HttpGet]
		[Route("GetNature/{code}")]
		[ProducesResponseType(typeof(Nature), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(GlobalExceptionDetails), StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetNature([FromRoute] string code)
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
		[Route("GetNatureLocalized/{code}")]
		[ProducesResponseType(typeof(EntityLocalized), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(GlobalExceptionDetails), StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetNatureLocalized(
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
