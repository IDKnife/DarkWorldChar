using System.Threading.Tasks;
using DarkWorldChar.Model.MainModel;
using DarkWorldChar.Repositories.Interfaces;

namespace DarkWorldChar.Services.Interfaces
{
	internal class LocalizationService : ILocalizationService
	{
		private readonly ILocalizationRepository m_repository;

		public LocalizationService(ILocalizationRepository repository)
		{
			m_repository = repository;
		}

		public async Task CreateEntity(EntityLocalized entity)
		{
			await m_repository.CreateEntity(entity);
		}

		public async Task DeleteEntity(string code, string language)
		{
			await m_repository.DeleteEntity(code, language);
		}

		public async Task<EntityLocalized> ReadEntity(string code, string language)
		{
			return await m_repository.ReadEntity(code, language);
		}

		public async Task UpdateEntity(EntityLocalized entity)
		{
			await m_repository.UpdateEntity(entity);
		}
	}
}
