using Signals.Game;

namespace cooking.controller
{
	public class HideGameCommand  : BaseCommand
	{
		[Inject] public HideGameSignal HideGameSignal { get; set; }
		
		public override void Execute()
		{
			base.Execute();
			
			HideGameSignal.Dispatch();
		}
	}
}