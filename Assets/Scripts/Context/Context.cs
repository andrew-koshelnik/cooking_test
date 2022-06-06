using System.Threading;
using Base.Root;
using Commands;
using Commands.Character;
using Commands.Game;
using cooking.controller;
using cooking.Events;
using cooking.views.branding;
using Events;
using Game;
using Game.Services;
using Models;
using Models.Layers;
using Signals;
using Signals.Game;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;
using Views;
using Views.Character;
using Views.Game;
using Views.GameCoinsPanel;
using Views.GameHud;
using Views.GameTimerPanel;
using Views.Juice;
using Views.Loading;
using Views.Order;
using Views.Pan;
using Views.Plate;
using Views.PlayPanel;
using Views.SoftCurrencyPanel;
using Views.StarPanel;
using Timer = Game.Services.Timer;

namespace cooking.context
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
            MapManagers();
            MapServices();
            MapSignals();
            MapModels();
            MapCommands();
            MapView();
        }

        private void MapManagers()
        {
            injectionBinder.Bind<GameManager>().ToSingleton();
        }

        private void MapServices()
        {
            injectionBinder.Bind<AssetService>().ToSingleton();
            injectionBinder.Bind<Timer>().ToSingleton();
            injectionBinder.Bind<CancellationTokenService>().ToSingleton();
            injectionBinder.Bind<AssetBundleService>().ToSingleton();
        }

        private void MapSignals()
        {
            injectionBinder.Bind<HideLoadingSignal>().ToSingleton();
            injectionBinder.Bind<CurrencyChangeSignal>().ToSingleton();
            injectionBinder.Bind<GameTimerEndedSignal>().ToSingleton();
            injectionBinder.Bind<HideLobbyHudSignal>().ToSingleton();
            injectionBinder.Bind<HideLobbySignal>().ToSingleton();
            injectionBinder.Bind<ShowLobbyHudSignal>().ToSingleton();
            injectionBinder.Bind<ShowLobbySignal>().ToSingleton();
            injectionBinder.Bind<HideGameHudSignal>().ToSingleton();
            injectionBinder.Bind<HideGameSignal>().ToSingleton();
            injectionBinder.Bind<ShowGameHudSignal>().ToSingleton();
            injectionBinder.Bind<ShowGameSignal>().ToSingleton();
            injectionBinder.Bind<InitGameSpawnPointsSignal>().ToSingleton();
            injectionBinder.Bind<CharacterMoveCompleteSignal>().ToSingleton();
            injectionBinder.Bind<ShowOrderSignal>().ToSingleton();
            injectionBinder.Bind<HideOrderSignal>().ToSingleton();
            injectionBinder.Bind<IngredientClickSignal>().ToSingleton();
            injectionBinder.Bind<InitPanModelsSignal>().ToSingleton();
            injectionBinder.Bind<SpawnIngredientOnPanSignal>().ToSingleton();
            injectionBinder.Bind<DishCookedSignal>().ToSingleton();
            injectionBinder.Bind<RemoveIngredientFromSourceSignal>().ToSingleton();
            injectionBinder.Bind<SpawnIngredientOnPlateSignal>().ToSingleton();
            injectionBinder.Bind<CharacterWaitTimerChangeSignal>().ToSingleton();
            injectionBinder.Bind<MoveCharacterSignal>().ToSingleton();
            injectionBinder.Bind<DestroyCharacterSignal>().ToSingleton();
            injectionBinder.Bind<OrderUpdateSignal>().ToSingleton();
            injectionBinder.Bind<TryConsumeDishSignal>().ToSingleton();
            injectionBinder.Bind<RemoveDishFromSourceSignal>().ToSingleton();
            injectionBinder.Bind<OrderUpdatedSignal>().ToSingleton();
            injectionBinder.Bind<OrderCompletedSignal>().ToSingleton();
            injectionBinder.Bind<SpawnIngredientOnJuiceMachineSignal>().ToSingleton();
            injectionBinder.Bind<StartMakingJuiceSignal>().ToSingleton();
            injectionBinder.Bind<FinishMakingJuiceSignal>().ToSingleton();
            injectionBinder.Bind<LevelCompleteSignal>().ToSingleton();
            injectionBinder.Bind<SwitchToLobbySignal>().ToSingleton();
            injectionBinder.Bind<ResetWaiterPositionSignal>().ToSingleton();
            injectionBinder.Bind<RestartGameSignal>().ToSingleton();
        }

        private void MapModels()
        {
            injectionBinder.Bind<LayerModel>().ToSingleton();
            injectionBinder.Bind<InventoryModel>().ToSingleton();
            injectionBinder.Bind<GameModel>().ToSingleton();
            injectionBinder.Bind<LevelModel>().ToSingleton();
            injectionBinder.Bind<CharacterSpawnModel>().ToSingleton();
        }

        private void MapView()
        {
            mediationBinder.Bind<RootView>().To<RootMediator>();
            mediationBinder.Bind<LoadingView>().To<LoadingMediator>();
            mediationBinder.Bind<LobbyView>().To<LobbyMediator>();
            mediationBinder.Bind<LobbyHudView>().To<LobbyHudMediator>();
            mediationBinder.Bind<GameHudView>().To<GameGudMediator>();
            mediationBinder.Bind<SoftCurrencyPanelView>().To<SoftCurrencyPanelMediator>();
            mediationBinder.Bind<StarPanelView>().To<StarPanelMediator>();
            mediationBinder.Bind<PlayPanelView>().To<PlayPanelMediator>();
            mediationBinder.Bind<GameTimerPanelView>().To<GameTimerPanelMediator>();
            mediationBinder.Bind<GameCoinsPanelView>().To<GameCoinsPanelMediator>();
            mediationBinder.Bind<GameView>().To<GameMediator>();
            mediationBinder.Bind<CharacterView>().To<CharacterMediator>();
            mediationBinder.Bind<PanView>().To<PanMediator>();
            mediationBinder.Bind<PlateView>().To<PlateMediator>();
            mediationBinder.Bind<OrderView>().To<OrderMediator>();
            mediationBinder.Bind<JuiceMachineView>().To<JuiceMachineMediator>();
            mediationBinder.Bind<LevelCompletePopupView>().To<LevelCompletePopupMediator>();
        }

        private void MapCommands()
        {
            commandBinder.Bind<InitSignal>()
                .To<InitCommand>()
                .To<WaitCommand>()
                .To<LoadLobbyCommand>()
                .To<LoadLobbyHudCommand>()
                .To<LoadGameHudCommand>()
                .To<LoadGameCommand>()
                .To<LoadGameConfigCommand>()
                .To<LoadDishConfigCommand>()
                .To<LoadLevelConfigCommand>()
                .To<LoadOrdersConfigCommand>()
                .To<LoadWaitersConfigCommand>()
                .To<LoadIngredientsConfigsCommand>()
                .To<SpawnWaitersCommand>()
                .To<HideGameCommand>()
                .To<HideGameHudCommand>()
                .To<HideLoadingCommand>()
                .InSequence()
                .Once();

            commandBinder.Bind<InitLayersSignal>().To<InitLayersCommand>();
            commandBinder.Bind<ChangeSoundSignal>().To<ChangeSoundCommand>();
            commandBinder.Bind<OpenSettingsSignal>().To<OpenSettingsCommand>();

            commandBinder.Bind<StartGameSignal>()
                .To<StartGameCommand>()
                .To<HideLobbyHudCommand>()
                .To<HideLobbyCommand>()
                .To<ShowGameHudCommand>()
                .To<ShowGameCommand>()
                .To<BeginGameCommand>()
                .InSequence();

            commandBinder.Bind<RestartGameSignal>()
                .To<StartGameCommand>()
                .To<BeginGameCommand>()
                .InSequence();

            commandBinder.Bind<BeginGameSignal>()
                .To<StartGameTimerCommand>()
                .To<StartWaitersMoveCommand>();
            
            commandBinder.Bind<CharacterMoveCompleteSignal>()
                .To<TryFreeExpiredWaiterCommand>()
                .To<GenerateOrderCommand>()
                .To<ShowOrderCommand>()
                .To<StartWaitTimerCommand>()
                .To<HideOrderCommand>()
                .To<HideCharacterCommand>()
                .InSequence();

            commandBinder.Bind<SwitchToLobbySignal>()
                .To<HideGameCommand>()
                .To<HideGameHudCommand>()
                .To<ShowLobbyHudCommand>()
                .To<ShowLobbyCommand>()
                .To<ShowExpRewardAnimationCommand>();
                
            commandBinder.Bind<IngredientClickSignal>()
                .To<TryStartCookingOnPanCommand>()
                .To<TryAddIngredientOnPlateCommand>()
                .To<TryStartCookingJuiceCommand>()
                .To<TryRemoveExpiredDishCommand>();

            commandBinder.Bind<TryConsumeDishSignal>()
                .To<TryConsumeDishCommand>()
                .To<CheckReadyOrdersCommand>();

            commandBinder.Bind<RemoveDishFromSourceSignal>()
                .To<RemoveDishFromSourceCommand>();

            commandBinder.Bind<OrderCompletedSignal>()
                .To<AddRewardForOrderCommand>()
                .To<HideOrderCommand>()
                .To<HideCharacterCommand>()
                .To<CheckLevelCompleteConditionCommand>();

            commandBinder.Bind<LevelCompleteSignal>()
                .To<ShowLevelCompletePopupCommand>()
                .To<AddPendingRewardCommand>()
                .To<UpdateLevelCommand>()
                .To<ResetWaitersCommand>()
                .To<ResetPlatesCommand>()
                .To<ResetPansCommand>()
                .To<ResetJuiceMachineCommand>()
                .To<StopAllAsyncOperationsCommand>()
                .InParallel();
            
            commandBinder.Bind<InitGameSpawnPointsSignal>().To<InitGameSpawnPointsCommand>();
            commandBinder.Bind<InitPanModelsSignal>().To<InitPanModelsCommand>();
            commandBinder.Bind<InitPlateModelsSignal>().To<InitPlateModelsCommand>();
            commandBinder.Bind<LeaveGameSignal>().To<LeaveGameCommand>();
        }
    }
}