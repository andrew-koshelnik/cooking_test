using System.Linq;
using cooking.so;
using Models;
using UnityEngine;

namespace cooking.controller
{
	public class LoadWaitersConfigCommand : BaseCommand
	{
		[Inject] public GameModel GameModel { get; set; }

		public override void Execute()
		{
			base.Execute();
			
			var configs = Resources.LoadAll<WaiterConfig>("SO/Waiters");
			
			if (configs != null)
			{
				GameModel.WaiterConfigs = configs.ToList();
			}
		}
	}
}