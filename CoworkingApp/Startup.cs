using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Mocks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CoworkingApp
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IRoomType, MockRoomType>();
			services.AddTransient<IRoom, MockRoom>();
			services.AddMvc(mvcOtions => {
				mvcOtions.EnableEndpointRouting = false;
			});

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();
			app.UseStaticFiles();
			app.UseMvcWithDefaultRoute();
		}
	}
}
