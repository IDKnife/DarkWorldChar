using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace DarkWorldChar.Model.MainModel
{
	[BsonIgnoreExtraElements]
	public class Auspice : Entity
	{
		[Required]
		public int InitialRage { get; set; }

		[Required]
		public List<string> BeginningGifts { get; set; }

		[Required]
		public List<BeginningRenown> BeginningRenown { get; set; }
	}
}
