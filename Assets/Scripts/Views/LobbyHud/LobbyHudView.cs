using System;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Game
{
    public class LobbyHudView : View
    {
        public void Init()
        {
            
        }

        private void AddListeners()
        {
            
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            
            AddListeners();
        }

        private void RemoveListeners()
        {
            
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            RemoveListeners();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}