using System.Collections.Generic;
using cooking.Enum;
using UnityEngine;
using VO;

namespace cooking.so
{
	[CreateAssetMenu(fileName = "Order_", menuName = "ScriptableObjects/Order", order = 5)]
	public class OrderConfig : ScriptableObject
	{
		public int MinNumOfDishes;
		public int MaxNumOfDishes;

		public List<RewardConfig> Reward;
		
		public List<Dishes> PossibleDishes;
	}
}