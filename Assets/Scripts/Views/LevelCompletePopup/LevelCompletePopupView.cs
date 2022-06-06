using System;
using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
	public class LevelCompletePopupView : View
	{
		[SerializeField] private TextMeshProUGUI _levelText;
		[SerializeField] private TextMeshProUGUI _coinsText;
		[SerializeField] private Button _lobbyButton;
		[SerializeField] private Button _retryButton;
		[SerializeField] private Image _winImage;
		[SerializeField] private Image _loseImage;
		
		public event Action OnLobbyClick = delegate { };
		public event Action OnRetryClick = delegate { };
		
		public void SetLevelText(string text)
		{
			_levelText.text = text;
		}
		
		public void SetCoinsText(string text)
		{
			_coinsText.text = text;
		}
		
		protected override void OnEnable()
		{
			base.OnEnable();
			
			_lobbyButton.onClick.AddListener(LobbyClick);
			_retryButton.onClick.AddListener(RetryClick);
		}

		private void LobbyClick()
		{
			OnLobbyClick.Invoke();
		}

		private void RetryClick()
		{
			OnRetryClick.Invoke();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			
			_lobbyButton.onClick.RemoveListener(LobbyClick);
			_retryButton.onClick.RemoveListener(RetryClick);
		}

		public void SetContent(bool isWin)
		{
			_winImage.gameObject.SetActive(isWin);
			_loseImage.gameObject.SetActive(!isWin);
			
			_lobbyButton.gameObject.SetActive(isWin);
			_retryButton.gameObject.SetActive(!isWin);
		}
	}
}