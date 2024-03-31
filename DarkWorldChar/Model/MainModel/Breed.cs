using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace DarkWorldChar.Model.MainModel
{
	[BsonIgnoreExtraElements]
	public class Breed : Entity
	{
		[Required]
		public int InitialGnosis { get; set; }

		[Required]
		public List<string> BeginningGifts { get; set; }
	}
}
