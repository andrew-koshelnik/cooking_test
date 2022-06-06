using System.Collections.Generic;
using Game;

namespace Models.Layers
{
    public class LayerModel : ILayerModel
    {
        public List<Layer> Layers = new List<Layer>();

        public void Add(Layer layer)
        {
            if(Layers.Find(l=>l.Type == layer.Type) == null)
                Layers.Add(layer);
        }
    }
}