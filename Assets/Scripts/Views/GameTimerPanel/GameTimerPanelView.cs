using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;

namespace Views.GameTimerPanel
{
	public class GameTimerPanelView : View
	{
		[SerializeField] private TextMeshProUGUI _timeText;
		
		public void SetText(string text)
		{
			_timeText.text = text;
		}
	}
}