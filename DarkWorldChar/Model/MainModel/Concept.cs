using System.ComponentModel.DataAnnotations;

namespace DarkWorldChar.Model.MainModel
{
	public class Concept
	{
		[Required]
		public string Breed { get; set; }

		[Required]
		public string Auspice { get; set; }

		[Required]
		public string Tribe { get; set; }

		[Required]
		public string Nature { get; set; }
	}
}
