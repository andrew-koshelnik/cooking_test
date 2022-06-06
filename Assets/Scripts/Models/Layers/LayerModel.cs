using System.Collections.Generic;
using Base.UI;

namespace Models.Layers
{
    public class LayerModel : ILayerModel
    {
        private List<RenderLayer> _layers = new List<RenderLayer>();

        public void Add(RenderLayer layer)
        {
            if(_layers.Find(l=>l.ID == layer.ID) == null)
                _layers.Add(layer);
        }
    }
}