using System;
using System.Collections.Generic;
using System.Linq;
using cooking.Enum;
using cooking.so;
using UnityEngine.UIElements;

namespace Models
{
	public class GameModel
	{
		public GameConfig GameConfig { get; set; }
		public JuiceMachineModel JuiceMachineModel { get; set; } = new JuiceMachineModel(Guid.NewGuid().ToString(), true);
		
		public List<LevelConfig> LevelConfigs { get; set; } = new List<LevelConfig>();
		public List<DishConfig> DishConfigs { get; set; } = new List<DishConfig>();
		public List<OrderConfig> OrderConfigs { get; set; } = new List<OrderConfig>();
		public List<WaiterConfig> WaiterConfigs { get; set; } = new List<WaiterConfig>();
		public List<IngredientConfig> IngredientsConfigs { get; set; } = new List<IngredientConfig>();
		public List<WaiterModel> WaitersModels { get; set; } = new List<WaiterModel>();
		public List<OrderModel> OrderModels { get; set; } = new List<OrderModel>();
		public List<PanModel> PanModels { get; set; } = new List<PanModel>();
		public List<DishSourceModel> PlateModels { get; set; } = new List<DishSourceModel>();

		public IngredientConfig GetIngredientConfig(Ingredients ingredient)
		{
			return IngredientsConfigs.FirstOrDefault(p => p.Type == ingredient);
		}

		public IBaseSourceModel GetSourceModel(string id)
		{
			var panModel = PanModels.FirstOrDefault(p => p.ID == id);
			var plateModel = PlateModels.FirstOrDefault(p => p.ID == id);

			return panModel != null ? panModel : plateModel;
		}
	}
}