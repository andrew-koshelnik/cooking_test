using System;
using UnityEngine;
using UnityEngine.UIElements;
using Views.BasePanel;
using Button = UnityEngine.UI.Button;

namespace Views.Pan
{
	public class PanView : BasePanelView
	{
		[SerializeField] public Transform BurgerHolder;
		[SerializeField] private Button _button;
		[SerializeField] private Transform _cookTimer;
		[SerializeField] private Transform _expireTimer;

		public event Action OnClick = delegate { };
		
		protected override void OnEnable()
		{
			base.OnEnable();
			
			_button.onClick.AddListener(Click);
		}

		private void Click()
		{
			OnClick.Invoke();
		}

		public void SetActiveCookTimer(bool isActive)
		{
			_cookTimer.gameObject.SetActive(isActive);
		}
		
		public void SetActiveExpireTimer(bool isActive)
		{
			_expireTimer.gameObject.SetActive(isActive);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			
			_button.onClick.RemoveListener(Click);
		}
	}
}