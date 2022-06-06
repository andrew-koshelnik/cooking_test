using surf.Enum;
using UnityEngine;

namespace Base.UI
{
    public class RenderLayer
    {
        private readonly GameObject _canvas;
        public readonly Layers ID;

        public RenderLayer(GameObject canvas, Layers id)
        {
            _canvas = canvas;
            ID = id;
        }

        public void Add(MonoBehaviour behaviour)
        {
            Add(behaviour.gameObject);
        }

        public void Add(GameObject gameObject)
        {
            gameObject.transform.SetParent(_canvas.transform, false);
        }
        
        public void Add(GameObject gameObject, bool saveWorldPosition = false)
        {
            gameObject.transform.SetParent(_canvas.transform, saveWorldPosition);
        }
    }
}