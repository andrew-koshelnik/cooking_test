using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Views.BasePanel;

namespace Views.SoftCurrencyPanel
{
	public class SoftCurrencyPanelView : BasePanelView
	{
		[SerializeField] private TextMeshProUGUI _currencyText;
		[SerializeField] private Button _button;
		
		public void SetText(string text)
		{
			_currencyText.text = text;
		}
	}
}