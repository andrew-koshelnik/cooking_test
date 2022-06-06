using UnityEngine;

namespace cooking.so
{
	[CreateAssetMenu(fileName = "Waiter_", menuName = "ScriptableObjects/Waiter", order = 6)]
	public class WaiterConfig : ScriptableObject
	{
		public string Name;
		public int WaitTime;
		public GameObject Prefab;
	}
}