using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace DarkWorldChar.Model.MainModel
{
	[BsonIgnoreExtraElements]
	public class Tribe : Entity
	{
		[Required]
		public int InitialWillpower { get; set; }

		[Required]
		public List<string> BanishedBackgrounds { get; set; }

		[Required]
		public List<string> BeginningGifts { get; set; }
	}
}
