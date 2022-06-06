using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Views.Plate
{
	public class PlateView : View, IPointerClickHandler
	{
		[SerializeField] public Transform Holder;
		[SerializeField] private Button _button;
		
		public event Action OnClick = delegate { };
		public event Action OnDoubleClick = delegate { };
		
		protected override void OnEnable()
		{
			base.OnEnable();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			int clickCount = eventData.clickCount;

			if (clickCount == 1)
				SingleClick();
			else if (clickCount >= 2)
				DoubleClick();
		}

		void SingleClick()
		{
			OnClick.Invoke();
		}

		void DoubleClick()
		{
			OnDoubleClick.Invoke();
		}
	}
}