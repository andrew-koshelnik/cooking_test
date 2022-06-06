using System;
using cooking.so;

namespace Models
{
	public class LevelModel
	{
		public LevelConfig LevelConfigConfiguration { get; set; }
		public int CurrentLevelNumber { get; set; } = 1;
		
		public DateTime EndTime => _endTime;
		public TimeSpan TimeLeft => _endTime - DateTime.UtcNow;
		public int SurvedDishes;
		public bool IsWin;
		
		private DateTime _endTime;

		public void CalculateEndTime()
		{
			_endTime = DateTime.UtcNow.AddSeconds(LevelConfigConfiguration.Duration);
		}
	}
}