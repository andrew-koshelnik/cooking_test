using Models;
using Signals.Game;

namespace cooking.controller
{
	public class ShowOrderCommand : BaseCommand
	{
		[Inject] public ShowOrderSignal ShowOrderSignal { get; set; }
		[Inject] public WaiterModel WaiterModel { get; set; }

		public override void Execute()
		{
			base.Execute();

			if (!WaiterModel.IsExpired)
			{
				ShowOrderSignal.Dispatch(WaiterModel.ID);
			}
		}
	}
}