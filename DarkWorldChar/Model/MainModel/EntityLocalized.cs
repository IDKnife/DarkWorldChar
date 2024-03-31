using System.ComponentModel.DataAnnotations;

namespace DarkWorldChar.Model.MainModel
{
	public class EntityLocalized : Entity
	{
		[Required]
		public string Language { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }
	}
}
