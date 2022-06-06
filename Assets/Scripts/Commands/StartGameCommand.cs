using cooking.Enum;
using Models;

namespace cooking.controller
{
    public class StartGameCommand : BaseCommand
    {
        [Inject] public LevelModel LevelModel { get; set; }
        [Inject] public InventoryModel InventoryModel { get; set; }
        public override void Execute()
        {
            base.Execute();

            LevelModel.SurvedDishes = 0;
            
            InventoryModel.Remove(Currency.PendingCoins, InventoryModel.Value(Currency.PendingCoins));
        }
    }
}