using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace DarkWorldChar.Model.MainModel
{
	[BsonIgnoreExtraElements]
	public class EntityLocalized : Entity
	{
		[Required]
		public string Language { get; set; }

		public string? Name { get; set; }

		public string? Description { get; set; }

		public Dictionary<string, string>? AdditionalDescriptions { get; set; }
	}
}
