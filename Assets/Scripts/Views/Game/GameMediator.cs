using System;
using DG.Tweening;
using Events;
using strange.extensions.mediation.impl;
using surf.Events;
using UnityEngine;

namespace Views.Game
{
    public class GameMediator : EventMediator
    {
        [Inject] public GameView View { get; set; }
        [Inject] public LeaveGameSignal LeaveGameSignal { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            
            View.Init();
            
            View.HomeClickSignal.AddListener(OnHomeClick);
        }

        private void OnHomeClick()
        {
            LeaveGameSignal.Dispatch();
        }
    }
}