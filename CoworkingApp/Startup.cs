using CoworkingApp.Data;
using CoworkingApp.Data.Interfaces;
using CoworkingApp.Data.Models;
using CoworkingApp.Data.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CoworkingApp
{
	public class Startup
	{
		private IConfigurationRoot _confString;

		public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
		{
			_confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			var connection = _confString.GetConnectionString("DefaultConnection");
			
			services.AddTransient<IRoomType, RoomTypeRepository>();
			services.AddTransient<IRoom, RoomRepository>();
			services.AddTransient<IPlace, PlaceRepository>();
			services.AddTransient<IRentApplication, RentApplicationRepository>();
			services.AddMvc(mvcOtions => {
				mvcOtions.EnableEndpointRouting = false;
			});
			services.AddDbContext<AppDbContent>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)), ServiceLifetime.Transient);
			services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDbContent>();
			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.User.RequireUniqueEmail = true;
			});
			services.AddAuthentication(options =>
			{
				options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			})
			.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
			{
				options.Cookie.HttpOnly = true;
				options.LoginPath = "/User/Login";
				options.SlidingExpiration = true;
			});
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped(sp => RentCart.GetCart(sp));
			services.AddMvc(mvcOtions =>
			{
				mvcOtions.EnableEndpointRouting = false;
			});
			services.AddMemoryCache();
			services.AddSession();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSession();
			app.UseDeveloperExceptionPage();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseStatusCodePages();
			app.UseStaticFiles();
			app.UseMvcWithDefaultRoute();
			app.UseMvc(routes => {
				routes.MapRoute(name: "default", template: "{controller-Home}/{action-Index}/{id?}");
				routes.MapRoute(name: "categoryFilter", template: "Room/{action}/{roomType?}", 
					defaults: new { Controller = "Room", action = "List" });
			});

			using (var scope = app.ApplicationServices.CreateScope())
			{
				AppDbContent content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
				UserManager<User> userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
				RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
				DbObjects.Initial(content);
				var task = Task.Run(async () => await DbObjects.InitialAsync(userManager, roleManager));
				task.Wait();
			}

		}
	}
}
