using System.Collections.Generic;
using cooking.controller;
using Models;
using Views.Pan;
using Views.Plate;

namespace Commands.Game
{
	public class InitPlateModelsCommand: BaseCommand
	{
		[Inject] public List<PlateView> PlateViews { get; set; }
		[Inject] public GameModel GameModel { get; set; }

		public override void Execute()
		{
			base.Execute();
			
			for (var i = 0; i < PlateViews.Count; i++)
			{
				var plateMediator = PlateViews[i].gameObject.GetComponent<PlateMediator>();
			
				if (plateMediator != null)
				{
					var model = new DishSourceModel($"Plate_{i}", true);
				
					GameModel.PlateModels.Add(model);
					
					plateMediator.DishSourceModel = model;
				}
			}
		}
	}
}