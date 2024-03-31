using System.Text.Json.Serialization;

namespace DarkWorldChar.Model.MainModel
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum RenownCombination
	{
		Any,
		Glory,
		Honor,
		Wisdom,
	}
}
