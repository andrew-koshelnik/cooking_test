using cooking.controller;
using cooking.Enum;
using Models;

namespace Commands.Game
{
	public class AddPendingRewardCommand : BaseCommand
	{
		[Inject] public InventoryModel InventoryModel { get; set; }
		[Inject] public bool Status { get; set; }
		
		public override void Execute()
		{
			base.Execute();
			
			InventoryModel.Add(Currency.Coins, InventoryModel.Value(Currency.PendingCoins));
		}
	}
}