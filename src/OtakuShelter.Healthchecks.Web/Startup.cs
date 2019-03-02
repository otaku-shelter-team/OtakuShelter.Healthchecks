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
				.AddUrlGroup(new Uri("http://accounts.staging.otaku-shelter.ru/health"), "Account")
				.AddUrlGroup(new Uri("http://profiles.staging.otaku-shelter.ru/health"), "Profile")
				.AddUrlGroup(new Uri("http://mangas.staging.otaku-shelter.ru/health"), "Manga")
				.AddUrlGroup(new Uri("http://errors.staging.otaku-shelter.ru/health"), "Error")
				.AddUrlGroup(new Uri("http://reviews.staging.otaku-shelter.ru/health"), "Reviews")
				.AddUrlGroup(new Uri("http://staging.otaku-shelter.ru"), "Frontend");

			services.AddHealthChecksUI();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseHealthChecks("/health", new HealthCheckOptions
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});
			
			app.UseHealthChecksUI(options => options.UIPath = "/dashboard");
		}
	}
}