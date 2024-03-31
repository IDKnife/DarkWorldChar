using System.ComponentModel.DataAnnotations;

namespace DarkWorldChar.Model.ViewModel
{
	public class CharacterInput
	{
		[Required]
		public string Breed { get; set; }

		[Required]
		public string Auspice { get; set; }

		[Required]
		public string Tribe { get; set; }
	}
}
