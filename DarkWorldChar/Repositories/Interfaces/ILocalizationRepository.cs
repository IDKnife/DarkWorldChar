using System.Threading.Tasks;
using DarkWorldChar.Model.MainModel;

namespace DarkWorldChar.Repositories.Interfaces
{
	public interface ILocalizationRepository
	{
		Task CreateEntity(EntityLocalized entity);

		Task<EntityLocalized> ReadEntity(string code, string language);

		Task UpdateEntity(EntityLocalized entity);

		Task DeleteEntity(string code, string language);
	}
}
