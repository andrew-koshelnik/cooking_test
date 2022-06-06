using System.Collections.Generic;
using cooking.Enum;
using cooking.so;

namespace Models
{
	public class DishSourceModel : IBaseSourceModel
	{
		public string ID { get; set; }
		public bool IsFree { get; set; }
		
		public List<Ingredients> CurrentIngredients = new List<Ingredients>();
		
		public DishSourceModel(string id, bool isFree)
		{
			ID = id;
			IsFree = isFree;
		}
	}
}