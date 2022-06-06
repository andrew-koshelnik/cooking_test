using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views.GameCoinsPanel
{
	public class GameCoinsPanelView : View
	{
		[SerializeField] private TextMeshProUGUI _currencyText;
		[SerializeField] private Button _button;
		
		public void SetText(string text)
		{
			_currencyText.text = text;
		}
	}
}