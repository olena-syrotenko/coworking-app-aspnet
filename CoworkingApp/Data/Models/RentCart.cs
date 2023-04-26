using CoworkingApp.Data.Utils;
using CoworkingApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoworkingApp.Data.Models
{
	public class RentCart
	{
		private readonly AppDbContent appDbContent;
		public RentCart(AppDbContent appDbContent)
		{
			this.appDbContent = appDbContent;
		}

		public string RentCartId { get; set; }
		public List<RentCartItem> rentCartItems { get; set; }

		public static RentCart GetCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = services.GetService<AppDbContent>();
			string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
			session.SetString("CartId", shopCartId);
			return new RentCart(context) { RentCartId = shopCartId };
		}

		public void AddToCart(PlaceViewModel placeDto)
		{
			appDbContent.RentCartItem.Add(new RentCartItem
			{
				rentCartId = RentCartId,
				placeId = placeDto.placeId,
				rentStart = placeDto.rentStart,
				rentEnd = placeDto.rentEnd,
				price = CalculationUtil.getTotalForPlace(placeDto.place, placeDto.rentStart, placeDto.rentEnd)
			});
			appDbContent.SaveChanges();
		}

		public void RemoveFromCart(int id)
        {
			appDbContent.RentCartItem.Remove(appDbContent.RentCartItem.Find(id));
			appDbContent.SaveChanges();
        }

		public List<RentCartItem> getRentItems()
		{
			return appDbContent.RentCartItem.Where(p => p.rentCartId == RentCartId)
				.Include(r => r.place).ThenInclude(p => p.room).ThenInclude(rm => rm.roomType)
				.ToList();
		}

		public void clear()
        {
			appDbContent.RentCartItem.RemoveRange(appDbContent.RentCartItem.Where(r => r.rentCartId == RentCartId));
			appDbContent.SaveChanges();
        }

	}
}