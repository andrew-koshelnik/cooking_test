using cooking.controller;
using Models;
using Signals.Game;

namespace Commands.Game
{
	public class ResetWaitersCommand : BaseCommand
	{
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public ResetWaiterPositionSignal ResetWaiterPositionSignal { get; set; }
		[Inject] public OrderUpdateSignal OrderUpdateSignal { get; set; }
		[Inject] public HideOrderSignal HideOrderSignal { get; set; }
		
		public override void Execute()
		{
			base.Execute();

			foreach (var waiter in GameModel.WaitersModels)
			{
				waiter.OrderModel = null;
				waiter.IsExpired = false;
				waiter.IsWaitingNewOrder = true;
				
				ResetWaiterPositionSignal.Dispatch(waiter.ID);
				OrderUpdateSignal.Dispatch(waiter);
				HideOrderSignal.Dispatch(waiter.ID);
			}
		}
	}
}