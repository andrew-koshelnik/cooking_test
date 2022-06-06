using System;
using System.Threading.Tasks;
using UnityEngine;

namespace cooking.controller
{
	public class WaitCommand : BaseCommand
	{
		public override void Execute()
		{
			base.Execute();
			
			Retain();
			Wait();
		}

		private async void Wait()
		{
			await Task.Delay(new TimeSpan(0, 0, 2));

			Release();
		}
	}
}