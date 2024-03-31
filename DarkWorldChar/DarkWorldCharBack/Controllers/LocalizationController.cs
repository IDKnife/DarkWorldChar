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
	public class LocalizationController : ControllerBase
	{
		private ILocalizationService m_localizationService;

		public LocalizationController(ILocalizationService localizationService)
		{
			m_localizationService = localizationService;
		}

		[HttpPost]
		[Route("AddLocalization")]
		[ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(GlobalExceptionDetails), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddLocalization([FromBody] EntityLocalized Localization)
		{
			await m_localizationService.CreateEntity(Localization);
			return ActionResultHelper.GetResult(StatusCodes.Status201Created);
		}
	}
}
