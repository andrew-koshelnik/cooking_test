using Commands.Game;
using Game.Services;
using Models;
using strange.extensions.mediation.impl;
using UnityEngine;
using Views.Pan;

namespace Views.Order
{
	public class OrderMediator : EventMediator
	{
		[Inject] public OrderView OrderView { get; set; }
		[Inject] public AssetService AssetService { get; set; }
		[Inject] public OrderUpdatedSignal OrderUpdatedSignal { get; set; }
		
		private OrderModel _orderModel;

		public OrderModel OrderModel
		{
			get
			{
				return _orderModel;
			}
			set
			{
				bool requiresUpdate = _orderModel != null && value != null && _orderModel.ID == value.ID;

				_orderModel = value;
				
				if (requiresUpdate)
				{
					UpdateDishesStatus();
				}
				else
				{
					CleanUpHolder();
					SpawnDishes();
				}
			}
		}

		public override void OnRegister()
		{
			base.OnRegister();
			
			OrderUpdatedSignal.AddListener(OnOrderUpdate);
		}

		public override void OnRemove()
		{
			base.OnRemove();
			
			OrderUpdatedSignal.RemoveListener(OnOrderUpdate);
		}

		private void OnOrderUpdate(OrderModel orderModel)
		{
			if (_orderModel != null && orderModel.ID == _orderModel.ID)
			{
				UpdateDishesStatus();
			}
		}

		private void SpawnDishes()
		{
			if(_orderModel == null)
				return;
			
			foreach (var dishModel in _orderModel.Dishes)
			{
				var instance = AssetService.SpawnAt(dishModel.DishConfig.Prefab, OrderView.ItemsHolder);
				var dishView = instance.GetComponent<DishView>();
				OrderView.Dishes.Add(dishView);
				dishView.MarkAsDone(dishModel.IsReady);
			}
		}

		private void UpdateDishesStatus()
		{
			for (var i = 0; i < _orderModel.Dishes.Count; i++)
			{
				OrderView.Dishes[i].MarkAsDone(_orderModel.Dishes[i].IsReady);
			}
		}

		public void CleanUpHolder()
		{
			foreach (Transform child in OrderView.ItemsHolder) 
			{
				Destroy(child.gameObject);
			}
			
			OrderView.Dishes.Clear();
		}
	}
}