using System;
using System.Runtime.CompilerServices;
using cooking.Enum;
using cooking.so;

namespace Models
{
	public class DishModel
	{
		public string ID;
		public bool IsReady;
		public DishConfig DishConfig;

		public DishModel(string id, bool isReady, DishConfig dishConfig)
		{
			ID = id;
			IsReady = isReady;
			DishConfig = dishConfig;
		}
	}
}