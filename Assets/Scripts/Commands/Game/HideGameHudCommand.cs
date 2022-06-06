using Signals.Game;

namespace cooking.controller
{
	public class HideGameHudCommand : BaseCommand
	{
		[Inject] public HideGameHudSignal HideGameHudSignal { get; set; }
		
		public override void Execute()
		{
			base.Execute();
			
			HideGameHudSignal.Dispatch();
		}
	}
}