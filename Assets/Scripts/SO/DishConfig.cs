using System.Collections.Generic;
using cooking.Enum;
using UnityEngine;

namespace cooking.so
{
	[CreateAssetMenu(fileName = "Dish", menuName = "ScriptableObjects/Dish", order = 3)]
	public class DishConfig: ScriptableObject
	{
		public string Name;
		public Dishes Type;
		public GameObject Prefab;
		public List<Ingredients> Ingredients = new List<Ingredients>();
	}
}