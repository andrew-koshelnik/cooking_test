using cooking.controller;
using cooking.Enum;
using DG.Tweening;
using Game.Services;
using Models;
using UnityEngine;

namespace Commands.Game
{
	public class ShowExpRewardAnimationCommand : BaseCommand
	{
		[Inject] public AssetService AssetService { get; set; }
		[Inject] public InventoryModel InventoryModel { get; set; }

		private GameObject _instance;
		public override void Execute()
		{
			base.Execute();

			if (InventoryModel.Value(Currency.PendingStars) > 0)
			{
				_instance = AssetService.Spawn(AssetsConstants.STAR, Layers.HUD);
				var starPanel = AssetService.Spawn(AssetsConstants.STARPANEL, Layers.HUD);

				if (starPanel != null)
				{
					_instance.transform.localScale = Vector3.zero;
					var sequence = DOTween.Sequence();
					
					sequence
						.Append(_instance.transform.DOScale(Vector3.one, 0.5f))
						.Append(_instance.transform.DOLocalMove(starPanel.transform.localPosition, 0.3f));

					sequence.OnComplete(OnAnimationComplete);
					sequence.Play();
				}
			}
		}

		private void OnAnimationComplete()
		{
			GameObject.Destroy(_instance);
			InventoryModel.Add(Currency.Stars, InventoryModel.Value(Currency.PendingStars));
		}
	}
}