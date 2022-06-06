using System;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;
using Views.Pan;
using Views.Plate;

namespace Views.Game
{
	public class GameView: View
	{
		[SerializeField] public List<Transform> CharactersPositions;
		[SerializeField] public List<Transform> SpawnPoints;
		
		[SerializeField] public Transform LeftSpawnPoint;
		[SerializeField] public List<Transform> LeftCharactersPositions;
		[SerializeField] public Transform RightSpawnPoint;
		[SerializeField] public List<Transform> RightCharactersPositions;
		
		[SerializeField] public Transform CharactersHolder;
		
		[SerializeField] public List<PanView> Pans;
		[SerializeField] public List<PlateView> PlateViews;
		
		[SerializeField] public Button BunButton;
		[SerializeField] public Button BurgerButton;
		[SerializeField] public Button SaladButton;
		[SerializeField] public Button TomatoButton;
		[SerializeField] public Button JuiceMachineButton;
		
		public event Action BunButtonClick = delegate { };
		public event Action BurgerButtonClick = delegate { };
		public event Action SaladButtonClick = delegate { };
		public event Action TomatoButtonClick = delegate { };
		public event Action JuiceMachineButtonClick = delegate { };

		protected override void OnEnable()
		{
			base.OnEnable();
			
			BunButton.onClick.AddListener(OnBunClick);
			BurgerButton.onClick.AddListener(OnBurgerClick);
			SaladButton.onClick.AddListener(OnSaladClick);
			TomatoButton.onClick.AddListener(OnTomatoClick);
			JuiceMachineButton.onClick.AddListener(OnJuiceButtonClick);
		}

		private void OnJuiceButtonClick()
		{
			JuiceMachineButtonClick.Invoke();
		}

		private void OnBunClick()
		{
			BunButtonClick.Invoke();
		}

		private void OnBurgerClick()
		{
			BurgerButtonClick.Invoke();
		}

		private void OnSaladClick()
		{
			SaladButtonClick.Invoke();
		}

		private void OnTomatoClick()
		{
			TomatoButtonClick.Invoke();
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		public void Show()
		{
			gameObject.SetActive(true);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			
			BunButton.onClick.RemoveListener(OnBunClick);
			BurgerButton.onClick.RemoveListener(OnBurgerClick);
			SaladButton.onClick.RemoveListener(OnSaladClick);
			TomatoButton.onClick.RemoveListener(OnTomatoClick);
			JuiceMachineButton.onClick.RemoveListener(OnJuiceButtonClick);
		}
	}
}