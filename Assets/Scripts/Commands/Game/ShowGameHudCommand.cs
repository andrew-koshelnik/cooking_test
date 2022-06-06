using Signals.Game;

namespace cooking.controller
{
	public class ShowGameHudCommand : BaseCommand
	{
		[Inject] public ShowGameHudSignal ShowGameHudSignal { get; set; }
		
		public override void Execute()
		{
			base.Execute();
			
			ShowGameHudSignal.Dispatch();
		}
	}
}