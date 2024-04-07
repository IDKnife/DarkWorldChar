using DarkWorldChar.Model.MainModel;
using DarkWorldChar.Repositories.Implementations;
using DarkWorldChar.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DarkWorldChar.Repositories
{
	public static class RepositoryDependencyInjectionExtensions
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IRepository<Breed>, EntityRepository<Breed>>();
			services.AddScoped<IRepository<Tribe>, EntityRepository<Tribe>>();
			services.AddScoped<IRepository<Auspice>, EntityRepository<Auspice>>();
			services.AddScoped<IRepository<Nature>, EntityRepository<Nature>>();
			services.AddScoped<ILocalizationRepository, LocalizationRepository>();

			return services;
		}
	}
}
