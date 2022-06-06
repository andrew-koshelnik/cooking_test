using System.Collections.Generic;
using cooking.Enum;
using UnityEngine;

namespace cooking.so
{
	[CreateAssetMenu(fileName = "Ingredient_", menuName = "ScriptableObjects/Ingredient", order = 4)]
	public class IngredientConfig: ScriptableObject
	{
		public string Name;
		public Ingredients Type;
		public Cooker Cooker;
		public int CookingTime;
		public int ExpirationTime;
		public bool IsExpired;
		public Ingredients ExpiredIngredient;
		public bool IsReady;
		public Ingredients CookedIngredient;
		public GameObject Prefab;
		public List<Ingredients> RequiredIngredientsOnDish = new List<Ingredients>();
	}
}