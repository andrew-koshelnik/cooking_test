using Signals.Game;

namespace cooking.controller
{
	public class BeginGameCommand : BaseCommand
	{
		[Inject] public BeginGameSignal BeginGameSignal { get; set; }

		public override void Execute()
		{
			base.Execute();

			BeginGameSignal.Dispatch();
		}
	}
}