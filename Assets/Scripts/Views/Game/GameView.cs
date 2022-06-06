using System;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Game
{
    public class GameView : View
    {
        [SerializeField] private Button _homeButton;
        [SerializeField] private GameObject _topLeftAnchor;
        [SerializeField] private GameObject _bottomRightAnchor;
        [SerializeField] private RectTransform _topLeftAnchorUI;
        [SerializeField] private RectTransform _bottomRightAnchorUI;
        [SerializeField] private SpriteRenderer _border;
        [SerializeField] private Material _vortexMaterial;
        [SerializeField] private Image _hitImage;

        public Image HitImage => _hitImage;

        private Signal _homeClickSignal;

        public Material VortexMaterial => _vortexMaterial;

        public Signal HomeClickSignal => _homeClickSignal;
        
        public GameObject TopLeftAnchor => _topLeftAnchor;

        public GameObject BottomRightAnchor => _bottomRightAnchor;

        public RectTransform TopLeftAnchorUi => _topLeftAnchorUI;

        public RectTransform BottomRightAnchorUi => _bottomRightAnchorUI;

        public SpriteRenderer Border => _border;

        public void Init()
        {
            _homeClickSignal = new Signal();

            AddListeners();
        }

        private void AddListeners()
        {
            if(_homeClickSignal != null)
                _homeButton.onClick.AddListener(_homeClickSignal.Dispatch);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            
            AddListeners();
        }

        private void RemoveListeners()
        {
            _homeButton.onClick.RemoveListener(_homeClickSignal.Dispatch);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            RemoveListeners();
        }
    }
}