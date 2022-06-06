using Models;
using Signals.Game;

namespace cooking.controller
{
	public class HideOrderCommand : BaseCommand
	{
		[Inject] public HideOrderSignal HideOrderSignal { get; set; }
		[Inject] public WaiterModel WaiterModel { get; set; }

		public override void Execute()
		{
			base.Execute();

			if (WaiterModel.IsExpired)
			{
				HideOrderSignal.Dispatch(WaiterModel.ID);
			}
		}
	}
}