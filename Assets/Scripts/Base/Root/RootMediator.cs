using System;
using Events;
using strange.extensions.mediation.impl;
using surf.Events;

namespace Base.Root
{
    public class RootMediator : EventMediator
    {
        [Inject] public RootView view{ get; set;}
        [Inject] public InitLayersSignal InitLayersSignal{ get; set;}
        [Inject] public StartGameSignal StartGameSignal{ get; set;}
        [Inject] public LeaveGameSignal LeaveGameSignal{ get; set;}
        
        public override void OnRegister()
        {
            InitLayersSignal.Dispatch(view.Layers);
            LeaveGameSignal.AddListener(OnLeaveGame);
            StartGameSignal.AddListener(OnStartGame);
        }

        private void OnStartGame()
        {
           view.Game.SetActive(true); 
           view.GameHud.SetActive(true); 
           view.Branding.SetActive(false); 
        }

        private void Update()
        {
            
        }

        private void OnLeaveGame()
        {
            view.Game.SetActive(false); 
            view.GameHud.SetActive(false);
            view.Branding.SetActive(true); 
        }
    }
}