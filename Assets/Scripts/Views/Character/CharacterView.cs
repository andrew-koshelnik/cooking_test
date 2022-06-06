using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UIElements;
using Views.Order;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

namespace Views.Character
{
	public class CharacterView: View
	{
		[SerializeField] public OrderView OrderView;
		
		public void ShowOrder()
		{
			OrderView.gameObject.SetActive(true);
		}
		
		public void HideOrder()
		{
			OrderView.gameObject.SetActive(false);
		}

		public void SetTimer(float value)
		{
			OrderView.SetTimer(value);
		}
	}
}