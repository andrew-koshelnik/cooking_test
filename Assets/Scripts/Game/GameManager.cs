using Game.Services;
using Models;
using UnityEngine;

namespace Game
{
	public class GameManager
	{
		[Inject] public Timer Timer { get; set; }
		[Inject] public GameModel GameModel { get; set; }
		public MonoBehaviour RootMono { get; set; }

		public void StartGame()
		{
			Timer.OnSecond += OnSecondTick;
		}

		private void OnSecondTick()
		{
			
		}

		public void CompleteGame()
		{
			Timer.OnSecond -= OnSecondTick;
		}
	}
}