using Signals;

namespace cooking.controller
{
	public class ShowLobbyHudCommand: BaseCommand
	{
		[Inject] public ShowLobbyHudSignal ShowLobbyHudSignal { get; set; }
		
		public override void Execute()
		{
			base.Execute();
			
			ShowLobbyHudSignal.Dispatch();
		}
	}
}