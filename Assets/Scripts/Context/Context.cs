using Base.Root;
using Events;
using Models.Layers;
using strange.examples.signals;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using surf.controller;
using surf.Events;
using surf.views.branding;
using UnityEngine;
using Views.Game;

namespace surf.context
{
    public class Context : MVCSContext
    {
        public Context(MonoBehaviour view) : base(view)
        {
        }

        public Context(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
        }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }
		
        override public IContext Start()
        {
            base.Start();
            InitSignal startSignal= (InitSignal)injectionBinder.GetInstance<InitSignal>();
            startSignal.Dispatch();
            return this;
        }


        protected override void mapBindings()
        {
            MapSignals();
            MapModels();
            MapCommands();
            MapView();
        }

        private void MapSignals()
        {
        
        }

        private void MapModels()
        {
            injectionBinder.Bind<ILayerModel>().To<LayerModel>().ToSingleton();
        }

        private void MapView()
        {
            mediationBinder.Bind<RootView>().To<RootMediator>();
            mediationBinder.Bind<BrandingView>().To<BrandingMediator>();
            mediationBinder.Bind<GameView>().To<GameMediator>();
        }

        private void MapCommands()
        {
            commandBinder.Bind<InitSignal>().To<InitCommand>().Once();
            commandBinder.Bind<InitLayersSignal>().To<InitLayersCommand>();
            
            commandBinder.Bind<ChangeSoundSignal>().To<ChangeSoundCommand>();
            commandBinder.Bind<OpenSettingsSignal>().To<OpenSettingsCommand>();
            commandBinder.Bind<StartGameSignal>().To<StartGameCommand>();
            commandBinder.Bind<LeaveGameSignal>().To<LeaveGameCommand>();
        }
    }
}