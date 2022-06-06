using cooking.so;

namespace Models
{
	public class PanModel : IBaseSourceModel
	{
		public string ID { get; set; }
		public bool IsFree { get; set; }
		public DishConfig CurrentDish;

		public PanModel(string id, bool isFree)
		{
			ID = id;
			IsFree = isFree;
		}
	}
}