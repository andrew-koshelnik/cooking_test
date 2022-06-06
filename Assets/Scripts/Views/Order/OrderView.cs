using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Order
{
	public class OrderView : View
	{
		[SerializeField] public Transform ItemsHolder;
		[SerializeField] public List<DishView> Dishes;
		[SerializeField] private Slider _slider;
		[SerializeField] private Image _sliderImage;
		[SerializeField] private Color32 _colorDefault;
		[SerializeField] private Color32 _colorRed;

		public void SetTimer(float value)
		{
			_slider.value = value;

			if (_slider.value < 0.5f)
			{
				_sliderImage.color = _colorRed;
			}
			else
			{
				_sliderImage.color = _colorDefault;
			}
		}
	}
}