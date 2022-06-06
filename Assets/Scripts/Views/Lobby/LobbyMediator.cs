using System;
using cooking.controller;
using cooking.Events;
using Events;
using Signals;
using strange.extensions.mediation.impl;

namespace cooking.views.branding
{
    public class LobbyMediator : EventMediator
    {
        [Inject] public LobbyView View { get; set; }
        [Inject] public HideLobbySignal HideLobbySignal { get; set; }
        [Inject] public ShowLobbySignal ShowLobbySignal { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            
            HideLobbySignal.AddListener(HideLobby);
            ShowLobbySignal.AddListener(ShowLobby);
        }

        private void ShowLobby()
        {
            View.Show();
        }

        private void HideLobby()
        {
            View.Hide();
        }

        public override void OnRemove()
        {
            base.OnRemove();
            
            HideLobbySignal.RemoveListener(HideLobby);
            ShowLobbySignal.RemoveListener(ShowLobby);
        }
    }
}