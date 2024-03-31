using System.Threading.Tasks;
using DarkWorldChar.Model.MainModel;

namespace DarkWorldChar.Services.Interfaces
{
	public interface ILocalizationService
	{
		Task CreateEntity(EntityLocalized entity);

		Task<EntityLocalized> ReadEntity(string code, string language);

		Task UpdateEntity(EntityLocalized entity);

		Task DeleteEntity(string code, string language);
	}
}
