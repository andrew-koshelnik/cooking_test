using System.Linq;
using cooking.so;
using Game;
using Game.Services;
using Models;
using UnityEngine;

namespace cooking.controller
{
	public class LoadOrdersConfigCommand : BaseCommand
	{
		[Inject] public GameModel GameModel { get; set; }

		public override void Execute()
		{
			base.Execute();
			
			var configs = Resources.LoadAll<OrderConfig>("SO/Orders");
			
			if (configs != null)
			{
				GameModel.OrderConfigs = configs.ToList();
			}
		}
	}
}