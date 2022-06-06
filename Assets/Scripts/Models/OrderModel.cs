using System.Collections.Generic;
using cooking.so;

namespace Models
{
	public class OrderModel
	{
		public string ID;
		public OrderConfig OrderConfig;
		public List<DishModel> Dishes = new List<DishModel>();

		public OrderModel(string id, OrderConfig config)
		{
			OrderConfig = config;
			ID = id;
		}
	}
}