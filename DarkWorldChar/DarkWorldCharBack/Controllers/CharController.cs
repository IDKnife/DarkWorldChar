using System.Threading.Tasks;
using DarkWorldChar.Model.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DarkWorldChar.Backend.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[EnableCors(PolicyName = "DefaultPolicy")]
	public class CharController : ControllerBase
	{
		[HttpPost]
		[Route("GenerateCharacter")]
		public async Task<IActionResult> GenerateCharacter([FromBody] CharacterInput input)
		{
			return Ok();
		}
	}
}