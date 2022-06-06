using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;
using Views.BasePanel;

namespace Views.StarPanel
{
	public class StarPanelView : BasePanelView
	{
		[SerializeField] private TextMeshProUGUI _currencyText;

		public void SetText(string text)
		{
			_currencyText.text = text;
		}
	}
}