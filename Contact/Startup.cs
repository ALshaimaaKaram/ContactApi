using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact.Models;
using Contact.Models.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Contact
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddMvc();
			services.AddDbContext<ContactDbContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("ContactsDb")));	
			
			services.AddScoped<IContactRepository, ContactRepository>();

            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
              {
                  builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
              }));
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();
            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
            
        }
	}
}
