using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Base.Root
{
    public class RootView : View
    {
        [SerializeField] private List<GameObject> _layers;

        public List<GameObject> Layers => _layers;
    }
}