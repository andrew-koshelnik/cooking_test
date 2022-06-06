using System.Linq;
using cooking.so;
using Game.Services;
using Models;
using UnityEngine;

namespace cooking.controller
{
	public class LoadDishConfigCommand : BaseCommand
	{
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public AssetService AssetService { get; set; }

		public override void Execute()
		{
			base.Execute();
			
			var configs = Resources.LoadAll<DishConfig>("SO/Dishes");
			
			if (configs != null)
			{
				GameModel.DishConfigs = configs.ToList();
			}
		}
	}
}