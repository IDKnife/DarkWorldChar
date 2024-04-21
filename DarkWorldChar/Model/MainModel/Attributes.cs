using System.ComponentModel.DataAnnotations;

namespace DarkWorldChar.Model.MainModel
{
	public class Attributes
	{
		[Required]
		public int Strength { get; set; }

		[Required]
		public int Dexterity { get; set; }

		[Required]
		public int Stamina { get; set; }

		[Required]
		public int Charisma { get; set; }

		[Required]
		public int Manipulation { get; set; }

		[Required]
		public int Appearance { get; set; }

		[Required]
		public int Perception { get; set; }

		[Required]
		public int Intelligence { get; set; }

		[Required]
		public int Wits { get; set; }
	}
}
