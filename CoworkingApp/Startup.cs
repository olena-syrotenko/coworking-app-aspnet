using CoworkingApp.Data;
using CoworkingApp.Data.Interfaces;
using CoworkingApp.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoworkingApp
{
	public class Startup
	{
		private IConfigurationRoot _confString;

		public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
		{
			_confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
		}

		// _confString.GetConnectionString("DefaultConnection")

		public void ConfigureServices(IServiceCollection services)
		{
			var connection = _confString.GetConnectionString("DefaultConnection");
			
			services.AddTransient<IRoomType, RoomTypeRepository>();
			services.AddTransient<IRoom, RoomRepository>();
			services.AddMvc(mvcOtions => {
				mvcOtions.EnableEndpointRouting = false;
			});
			services.AddDbContext<AppDbContent>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));
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
