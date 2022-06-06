using cooking.controller;
using Models;

namespace Commands.Game
{
	public class AddRewardForOrderCommand : BaseCommand
	{
		[Inject] public WaiterModel WaiterModel { get; set; }
		[Inject] public InventoryModel InventoryModel { get; set; }

		public override void Execute()
		{
			base.Execute();

			if (WaiterModel.OrderModel != null)
			{
				foreach (var rewardConfig in WaiterModel.OrderModel.OrderConfig.Reward)
				{
					InventoryModel.Add(rewardConfig.Type, rewardConfig.Amount);
				}
			}
		}
	}
}