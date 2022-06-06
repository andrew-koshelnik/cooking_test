using Signals.Game;

namespace cooking.controller
{
	public class ShowGameCommand  : BaseCommand
	{
		[Inject] public ShowGameSignal ShowGameSignal { get; set; }
		
		public override void Execute()
		{
			base.Execute();
			
			ShowGameSignal.Dispatch();
		}
	}
}