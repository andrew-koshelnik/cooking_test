using System;
using Events;
using strange.extensions.mediation.impl;
using surf.Events;

namespace surf.views.branding
{
    public class BrandingMediator : EventMediator
    {
        [Inject] public BrandingView View { get; set; }

        [Inject] public ChangeSoundSignal ChangeSoundSignal { get; set; }
        [Inject] public OpenSettingsSignal OpenSettingsSignal { get; set; }
        [Inject] public StartGameSignal StartGameSignal { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            
            View.Init();
            
            View.PlayClickSignal.AddListener(OnPlayClicked);
            View.SettingsClickSignal.AddListener(OnSettingsClicked);
            View.SoundClickSignal.AddListener(OnSoundClicked);
        }

        private void OnSoundClicked(bool value)
        {
            ChangeSoundSignal.Dispatch(value);
        }

        private void OnSettingsClicked()
        {
            OpenSettingsSignal.Dispatch();
        }

        private void OnPlayClicked()
        {
            StartGameSignal.Dispatch();
        }
    }
}