using System;
using System.Linq;
using cooking.controller;
using cooking.so;
using Models;
using Random = UnityEngine.Random;

namespace Signals.Game
{
	public class GenerateOrderCommand : BaseCommand
	{
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public LevelModel LevelModel { get; set; }
		[Inject] public WaiterModel WaiterModel { get; set; }
		[Inject] public OrderUpdateSignal OrderUpdateSignal { get; set; }

		public override void Execute()
		{
			base.Execute();

			if (!WaiterModel.IsExpired)
			{
				var orderConfig = LevelModel.LevelConfigConfiguration.OrderConfig;
				
				int numberOfDishes = Random.Range(orderConfig.MinNumOfDishes, orderConfig.MaxNumOfDishes+1);
				
				WaiterModel.OrderModel = new OrderModel(Guid.NewGuid().ToString(), orderConfig);

				for (int i = 0; i < numberOfDishes; i++)
				{
					int randomDishIndex = Random.Range(0, orderConfig.PossibleDishes.Count);

					var dishConfig =
						GameModel.DishConfigs.FirstOrDefault(d =>
							d.Type == orderConfig.PossibleDishes[randomDishIndex]);
					
					WaiterModel.OrderModel.Dishes.Add(new DishModel(Guid.NewGuid().ToString(),false, dishConfig));	
				}
				
				OrderUpdateSignal.Dispatch(WaiterModel);
			}
		}
	}
}