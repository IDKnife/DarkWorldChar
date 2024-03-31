using System.Collections.Generic;
using System.Threading.Tasks;
using DarkWorldChar.Model.MainModel;

namespace DarkWorldChar.Services.Interfaces
{
	public interface IEntityService<T>
		where T : Entity
	{
		Task CreateEntity(T entity);

		Task CreateEntities(HashSet<T> entities);

		Task<T> ReadEntity(string code);

		Task<List<T>> ReadEntities();

		Task UpdateEntity(T entity);

		Task DeleteEntity(string code);

		Task DeleteEntities(HashSet<string> codes);
	}
}
