using System.Linq;
using cooking.controller;
using Models;
using Signals.Game;

namespace Commands.Character
{
	public class TryFreeExpiredWaiterCommand : BaseCommand
	{
		[Inject] public WaiterModel WaiterModel { get; set; }
		
		public override void Execute()
		{
			base.Execute();
			
			if (WaiterModel.IsExpired)
			{
				WaiterModel.IsWaitingNewOrder = true;
			}
		}
	}
}