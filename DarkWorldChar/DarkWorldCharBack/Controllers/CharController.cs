using System.Threading.Tasks;
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
	public class CharController : ControllerBase
	{
		private IValidateService m_validateService;

		public CharController(IValidateService validateService)
		{
			m_validateService = validateService;
		}

		[HttpPost]
		[Route("GenerateCharacter")]
		[ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(GlobalExceptionDetails), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> GenerateCharacter([FromBody] Character input)
		{
			m_validateService.Validate(input);
			return Ok();
		}
	}
}