using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Juice
{
	public class JuiceMachineView : View
	{
		public Image BowlImage;
		public Transform Holder;
		public Transform CookTimer;
		public List<Sprite> Stages;

		public void SetActiveCookTimer(bool isActive)
		{
			CookTimer.gameObject.SetActive(isActive);
		}
		
		public void SetProgress(float progress)
		{
			var step = 1 / (Stages.Count + 1);
			var imageIndex = progress / step;
		}
	}
}