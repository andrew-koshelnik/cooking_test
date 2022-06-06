using System;
using System.Security.Cryptography;
using DG.Tweening;
using Models;
using Signals.Game;
using strange.extensions.mediation.impl;
using Views.Order;

namespace Views.Character
{
	public class CharacterMediator: EventMediator
	{
		[Inject] public CharacterView View { get; set; }
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public CharacterMoveCompleteSignal CharacterMoveCompleteSignal { get; set; }
		[Inject] public ShowOrderSignal ShowOrderSignal { get; set; }
		[Inject] public HideOrderSignal HideOrderSignal { get; set; }
		[Inject] public CharacterWaitTimerChangeSignal CharacterWaitTimerChangeSignal { get; set; }
		[Inject] public MoveCharacterSignal MoveCharacterSignal { get; set; }
		[Inject] public DestroyCharacterSignal DestroyCharacterSignal { get; set; }
		[Inject] public OrderUpdateSignal OrderUpdateSignal { get; set; }
		[Inject] public ResetWaiterPositionSignal ResetWaiterPositionSignal { get; set; }

		public WaiterModel WaiterModel { get; set; }

		public override void OnRegister()
		{
			base.OnRegister();
			
			ShowOrderSignal.AddListener(ShowOrder);
			HideOrderSignal.AddListener(HideOrder);
			CharacterWaitTimerChangeSignal.AddListener(OnTimerChange);
			MoveCharacterSignal.AddListener(MoveCharacter);
			DestroyCharacterSignal.AddListener(SelfDestroy);
			OrderUpdateSignal.AddListener(OrderUpdated);
			ResetWaiterPositionSignal.AddListener(ResetPosition);
			
			View.HideOrder();
		}

		private void ResetPosition(string ID)
		{
			if (WaiterModel.ID == ID)
			{
				View.transform.localPosition = WaiterModel.SpawnPosition.Position.localPosition;
			}
		}

		private void OrderUpdated(WaiterModel waiterModel)
		{
			if (WaiterModel.ID == waiterModel.ID)
			{
				var orderMediator = View.OrderView.GetComponent<OrderMediator>();
				
				if (orderMediator != null)
				{
					orderMediator.OrderModel = WaiterModel.OrderModel;
				}
			}
		}

		private void SelfDestroy(WaiterModel waiterModel)
		{
			if (WaiterModel.ID == waiterModel.ID)
			{
				Destroy(this.gameObject);
			}
		}

		private void MoveCharacter(string ID, CharacterPositionModel positionModel)
		{
			if (WaiterModel.ID == ID)
			{
				var endX = positionModel.Position.localPosition.x;
				var time = MathF.Abs((endX - View.transform.localPosition.x) / GameModel.GameConfig.CharacterSpeed);
				View.transform.DOLocalMoveX(endX, time).OnComplete(OnMoveComplete);
			}
		}

		private void OnTimerChange(string characterID, float value)
		{
			if (WaiterModel.ID == characterID)
			{
				View.SetTimer(value);
			}
		}

		private void ShowOrder(string characterID)
		{
			if (WaiterModel.ID == characterID)
			{
				View.ShowOrder();
			}
		}

		private void HideOrder(string characterID)
		{
			if (WaiterModel.ID == characterID)
			{
				View.HideOrder();
			}
		}

		private void OnMoveComplete()
		{
			CharacterMoveCompleteSignal.Dispatch(WaiterModel);
		}

		public override void OnRemove()
		{
			base.OnRemove();
			
			ShowOrderSignal.RemoveListener(ShowOrder);
			HideOrderSignal.RemoveListener(HideOrder);
			CharacterWaitTimerChangeSignal.RemoveListener(OnTimerChange);
			MoveCharacterSignal.RemoveListener(MoveCharacter);
			DestroyCharacterSignal.RemoveListener(SelfDestroy);
			OrderUpdateSignal.RemoveListener(OrderUpdated);
			ResetWaiterPositionSignal.RemoveListener(ResetPosition);
		}
	}
}