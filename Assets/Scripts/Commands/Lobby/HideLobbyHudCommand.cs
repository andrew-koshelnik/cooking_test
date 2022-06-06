using Signals;

namespace cooking.controller
{
	public class HideLobbyHudCommand: BaseCommand
	{
		[Inject] public HideLobbyHudSignal HideLobbyHudSignal { get; set; }
		
		public override void Execute()
		{
			base.Execute();
			
			HideLobbyHudSignal.Dispatch();
		}
	}
}