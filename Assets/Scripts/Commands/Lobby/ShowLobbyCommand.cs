using Signals;

namespace cooking.controller
{
	public class ShowLobbyCommand : BaseCommand
	{
		[Inject] public ShowLobbySignal ShowLobbySignal { get; set; }
		
		public override void Execute()
		{
			base.Execute();
			
			ShowLobbySignal.Dispatch();
		}
	}
}