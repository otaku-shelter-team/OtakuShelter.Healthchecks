using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

using HealthChecks.UI.Client;

namespace OtakuShelter.Health
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddHealthChecks()
				.AddUrlGroup(new Uri("http://account.otaku-shelter.ru/health"), "Account")
				.AddUrlGroup(new Uri("http://profile.otaku-shelter.ru/health"), "Profile")
				.AddUrlGroup(new Uri("http://manga.otaku-shelter.ru/health"), "Manga")
				.AddUrlGroup(new Uri("http://error.otaku-shelter.ru/health"), "Error")
				.AddUrlGroup(new Uri("http://otaku-shelter.ru"), "Frontend");

			services.AddHealthChecksUI();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseHealthChecks("/health", new HealthCheckOptions
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});
			
			app.UseHealthChecksUI();
		}
	}
}