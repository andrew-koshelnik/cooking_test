using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace surf.views.branding
{
    public class BrandingView : View
    {
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Toggle _soundToggle;
        [SerializeField] private Button _playButton;
        [SerializeField] private TextMeshProUGUI _levelText;

        private Signal _settingsClickSignal;
        private Signal _playClickSignal;
        private Signal<bool> _soundClickSignal;
        
        public Signal SettingsClickSignal => _settingsClickSignal;
        public Signal PlayClickSignal => _playClickSignal;
        public Signal<bool> SoundClickSignal => _soundClickSignal;

        public void Init()
        {
            _settingsClickSignal = new Signal();
            _playClickSignal = new Signal();
            _soundClickSignal = new Signal<bool>();
        }

        private void AddListeners()
        {
            _settingsButton.onClick.AddListener(OnSettingsClick);
            _playButton.onClick.AddListener(OnPlayClick);
            _soundToggle.onValueChanged.AddListener(OnSoundClick);
        }

        private void OnPlayClick()
        {
            _playClickSignal.Dispatch();
        }

        private void OnSoundClick(bool value)
        {
            _soundClickSignal.Dispatch(value);
        }

        private void OnSettingsClick()
        {
            _settingsClickSignal.Dispatch();
        }
        
        
        private void RemoveListeners()
        {
            _settingsButton.onClick.RemoveListener(OnSettingsClick);
            _playButton.onClick.RemoveListener(OnPlayClick);
            _soundToggle.onValueChanged.RemoveListener(OnSoundClick); 
        }
        
        protected override void OnEnable()
        {
            base.OnEnable();
            
            AddListeners();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            RemoveListeners();
        }
    }
}