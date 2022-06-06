using System.Linq;
using cooking.controller;
using Models;
using Signals.Game;

namespace Commands.Character
{
	public class HideCharacterCommand : BaseCommand
	{
		[Inject] public WaiterModel WaiterModel { get; set; }
		[Inject] public MoveCharacterSignal MoveCharacterSignal { get; set; }

		public override void Execute()
		{
			base.Execute();

			if (WaiterModel.IsExpired && !WaiterModel.IsWaitingNewOrder)
			{
				MoveCharacterSignal.Dispatch(WaiterModel.ID, WaiterModel.SpawnPosition);
			}
		}
	}
}