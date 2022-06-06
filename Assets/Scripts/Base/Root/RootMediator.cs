using System;
using Events;
using strange.extensions.mediation.impl;
using cooking.Events;
using Game;
using Views.Game;

namespace Base.Root
{
    public class RootMediator : EventMediator
    {
        [Inject] public RootView view{ get; set;}
        [Inject] public InitLayersSignal InitLayersSignal{ get; set;}
        [Inject] public GameManager GameManager { get; set;}
        
        public override void OnRegister()
        {
            InitLayersSignal.Dispatch(view.Layers);
            GameManager.RootMono = view;
        }
    }
}