using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Base.Root
{
    public class RootView : View
    {
        [SerializeField] private List<Canvas> _layers;
        [SerializeField] private GameObject _game;
        [SerializeField] private GameObject _gameHud;
        [SerializeField] private GameObject _branding;

        public List<Canvas> Layers => _layers;
        public GameObject Game => _game;
        public GameObject GameHud => _gameHud;
        public GameObject Branding => _branding;
    }
}