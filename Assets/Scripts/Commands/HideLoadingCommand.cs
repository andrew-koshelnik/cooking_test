using Signals;

namespace cooking.controller
{
	public class HideLoadingCommand : BaseCommand
	{
		[Inject] public HideLoadingSignal HideLoadingSignal { get; set; }
		
		public override void Execute()
		{
			base.Execute();
			
			HideLoadingSignal.Dispatch();
		}
	}
}