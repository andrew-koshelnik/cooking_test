using System.Collections.Generic;
using Base.UI;
using Events;
using Models.Layers;
using strange.extensions.command.impl;
using surf.Enum;
using UnityEngine;

namespace surf.controller
{
    public class InitLayersCommand : BaseCommand
    {
        [Inject] public ILayerModel layerModel { get;set; }
        [Inject] public InitLayersSignal InitLayersSignal{get;set;}
        [Inject] public List<Canvas> Canvases{get;set;}
        
        public override void Execute()
        {
            base.Execute();
            
            foreach (var canvase in Canvases)
            {
                Layers _id = Layers.UNDEFINED;
                
                switch (canvase.gameObject.name)
                {
                    case "HUD": 
                        _id = Layers.HUD;
                        break;
                    case "WINDOWS": 
                        _id = Layers.WINDOWS;
                        break;
                    case "LOADING": 
                        _id = Layers.LOADING;
                        break;
                }
                
                layerModel.Add(new RenderLayer(canvase.gameObject, _id));
            }
        }
    }
}