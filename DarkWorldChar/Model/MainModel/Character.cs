using System.ComponentModel.DataAnnotations;

namespace DarkWorldChar.Model.MainModel
{
	public class Character
	{
		[Required]
		public Concept Concept { get; set; }

		[Required]
		public Attributes Attributes { get; set; }
	}
}
