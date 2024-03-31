using System.ComponentModel.DataAnnotations;

namespace DarkWorldChar.Model.MainModel
{
	public class Character
	{
		[Required]
		public Breed Breed { get; set; }

		[Required]
		public Auspice Auspice { get; set; }

		[Required]
		public Tribe Tribe { get; set; }
	}
}
