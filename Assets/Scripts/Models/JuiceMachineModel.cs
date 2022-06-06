using System;

namespace Models
{
	public class JuiceMachineModel : DishSourceModel
	{
		public bool IsCooking;
		
		public JuiceMachineModel(string id, bool isFree) : base(id, isFree)
		{
		}
	}
}