using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Services
{
	public class Timer
	{
		public event Action OnSecond = delegate { };

		public Timer()
		{
			StartTimer();
		}

		private async void StartTimer()
		{
			while (true)
			{
				await Task.Delay(new TimeSpan(0, 0, 1));

				OnSecond.Invoke();
			}
		}
	}
}