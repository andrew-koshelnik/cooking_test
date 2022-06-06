using System;
using DG.Tweening;
using Events;
using strange.extensions.mediation.impl;
using cooking.Events;
using Signals;
using UnityEngine;

namespace Views.Game
{
    public class LobbyHudMediator : EventMediator
    {
        [Inject] public LobbyHudView View { get; set; }
        [Inject] public HideLobbyHudSignal HideLobbyHudSignal { get; set; }
        [Inject] public ShowLobbyHudSignal ShowLobbyHudSignal { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            
            View.Init();
            
            HideLobbyHudSignal.AddListener(HideHud);
            ShowLobbyHudSignal.AddListener(ShowHud);
        }

        private void ShowHud()
        {
            View.Show();
        }

        private void HideHud()
        {
            View.Hide();
        }

        public override void OnRemove()
        {
            base.OnRemove();
            
            HideLobbyHudSignal.RemoveListener(HideHud);
            ShowLobbyHudSignal.RemoveListener(ShowHud);
        }
    }
}