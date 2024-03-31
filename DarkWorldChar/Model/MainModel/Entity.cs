using System.ComponentModel.DataAnnotations;

namespace DarkWorldChar.Model.MainModel
{
	public class Entity
	{
		[Required]
		public string Code { get; set; }
	}
}
