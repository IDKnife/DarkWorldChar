using DarkWorldChar.Model.MainModel;
using DarkWorldChar.Services.Implementations;
using DarkWorldChar.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DarkWorldChar.Services
{
	public static class ServiceDependencyInjectionExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IEntityService<Breed>, EntityService<Breed>>();
			services.AddScoped<IEntityService<Tribe>, EntityService<Tribe>>();
			services.AddScoped<IEntityService<Auspice>, EntityService<Auspice>>();
			services.AddScoped<ILocalizationService, LocalizationService>();

			return services;
		}
	}
}
