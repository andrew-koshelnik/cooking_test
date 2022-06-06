using Signals;

namespace cooking.controller
{
	public class HideLobbyCommand : BaseCommand
	{
		[Inject] public HideLobbySignal HideLobbySignal { get; set; }
		
		public override void Execute()
		{
			base.Execute();
			
			HideLobbySignal.Dispatch();
		}
	}
}