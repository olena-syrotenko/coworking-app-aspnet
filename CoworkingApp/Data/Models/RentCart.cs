using CoworkingApp.Data.Models.Dto;
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
		public double totalPrice { get; set; }
		public List<RentCartItem> rentCartItems { get; set; }

		public static RentCart GetCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = services.GetService<AppDbContent>();
			string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
			session.SetString("CartId", shopCartId);
			return new RentCart(context) { RentCartId = shopCartId, totalPrice = 0 };
		}

		public void AddToCart(PlaceDto placeDto)
		{
			double rentPrice = placeDto.place.room.price * ((placeDto.rentEnd - placeDto.rentStart).Days + 1);
			totalPrice += rentPrice;
			appDbContent.RentCartItem.Add(new RentCartItem
			{
				rentCartId = RentCartId,
				place = placeDto.place,
				rentStart = placeDto.rentStart,
				rentEnd = placeDto.rentEnd,
				price = rentPrice
			});
			appDbContent.SaveChanges();
		}

		public List<RentCartItem> getRentItems()
		{
			return appDbContent.RentCartItem.Where(p => p.rentCartId == RentCartId).Include(r => r.place).ToList();
		}

	}
}