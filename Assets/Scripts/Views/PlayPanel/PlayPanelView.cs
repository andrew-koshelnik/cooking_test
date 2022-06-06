using System;
using UnityEngine.UI;
using Views.BasePanel;

namespace Views.PlayPanel
{
	public class PlayPanelView : BasePanelView
	{
		public Button PlayButton;

		public event Action OnClick = delegate { };
		
		protected override void OnEnable()
		{
			base.OnEnable();
			
			PlayButton.onClick.AddListener(Click);
		}

		private void Click()
		{
			OnClick.Invoke();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			
			PlayButton.onClick.RemoveListener(Click);
		}
	}
}