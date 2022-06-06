using System.Collections.Generic;
using cooking.controller;
using Models;
using Views.Pan;

namespace Signals.Game
{
	public class InitPanModelsCommand : BaseCommand
	{
		[Inject] public List<PanView> PanViews { get; set; }
		[Inject] public GameModel GameModel { get; set; }

		public override void Execute()
		{
			base.Execute();
			
			for (var i = 0; i < PanViews.Count; i++)
			{
				var panMediator = PanViews[i].gameObject.GetComponent<PanMediator>();
			
				if (panMediator != null)
				{
					var model = new PanModel($"Pan_{i}", true);
				
					GameModel.PanModels.Add(model);
					
					panMediator.PanModel = model;
				}
			}
		}
	}
}