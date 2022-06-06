using System.Linq;
using Commands.Game;
using cooking.controller;
using cooking.Enum;
using Game.Utils;
using Models;
using Signals.Game;

namespace Commands
{
	public class TryConsumeDishCommand : BaseCommand
	{
		[Inject] public DishSourceModel DishSourceModel { get; set; }
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public OrderUpdatedSignal OrderUpdatedSignal { get; set; }
		[Inject] public RemoveDishFromSourceSignal RemoveDishFromSourceSignal { get; set; }
		[Inject] public LevelModel LevelModel { get; set; }

		public override void Execute()
		{
			base.Execute();

			Dishes dishType = GetDishType();
			
			foreach (var waiterModel in GameModel.WaitersModels)
			{
				if(waiterModel.IsExpired || waiterModel.IsWaitingNewOrder || waiterModel.OrderModel == null)
					continue;
				
				var dishInOrders = waiterModel.OrderModel.Dishes.FirstOrDefault(d=>!d.IsReady && d.DishConfig.Type == dishType);

				if (dishInOrders != null)
				{
					dishInOrders.IsReady = true;
					LevelModel.SurvedDishes++;
					
					RemoveDishFromSourceSignal.Dispatch(DishSourceModel);
					OrderUpdatedSignal.Dispatch(waiterModel.OrderModel);
					
					break;
				}
			}
		}

		private Dishes GetDishType()
		{
			foreach (var dishConfig in GameModel.DishConfigs)
			{
				if (dishConfig.Ingredients.AreEqual(DishSourceModel.CurrentIngredients))
				{
					return dishConfig.Type;
				}
			}
			return Dishes.none;
		}
	}
}