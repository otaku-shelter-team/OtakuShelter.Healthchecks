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
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddHealthChecks()
				.AddUrlGroup(new Uri("http://account.otaku-shelter.ru/swagger"), "Account")
				.AddUrlGroup(new Uri("http://profile.otaku-shelter.ru/swagger"), "Profile")
				.AddUrlGroup(new Uri("http://manga.otaku-shelter.ru/swagger"), "Manga");
				// .AddNpgSql("");

			services.AddHealthChecksUI();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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