using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;

namespace Views.Loading
{
	public class LoadingView : View
	{
		[SerializeField] private TextMeshProUGUI _loadingText;

		public void Hide()
		{
			gameObject.SetActive(false);
		}
	}
}