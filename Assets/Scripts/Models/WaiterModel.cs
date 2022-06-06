using cooking.so;

namespace Models
{
	public class WaiterModel
	{
		public string ID { get; set; }
		public CharacterPositionModel CharacterPosition { get; set; }
		public CharacterPositionModel SpawnPosition { get; set; }
		public WaiterConfig WaiterConfig { get; set; }
		public OrderModel OrderModel { get; set; }
		public bool IsExpired { get; set; }
		public bool IsWaitingNewOrder { get; set; }
		
		public WaiterModel(string id, CharacterPositionModel positionModel, CharacterPositionModel spawnPosition, WaiterConfig waiterConfig)
		{
			ID = id;
			CharacterPosition = positionModel;
			WaiterConfig = waiterConfig;
			SpawnPosition = spawnPosition;
		}
	}
}