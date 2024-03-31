using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DarkWorldChar.Model.MainModel;

namespace DarkWorldChar.Repositories.Interfaces
{
	public interface IRepository<T> : IDisposable
		where T : Entity
	{
		Task CreateEntity(T entity);

		Task<T> ReadEntity(string code);

		Task<List<T>> ReadEntities();

		Task UpdateEntity(T entity);

		Task DeleteEntity(string code);
	}
}
