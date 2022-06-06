using cooking.controller;
using Game.Services;

namespace Commands
{
	public class StopAllAsyncOperationsCommand : BaseCommand
	{
		[Inject] public CancellationTokenService CancellationTokenService { get; set; }

		public override void Execute()
		{
			base.Execute();
			
			CancellationTokenService.Cancel();
		}
	}
}