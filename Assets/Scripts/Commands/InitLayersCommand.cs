using System.Collections.Generic;
using cooking.Enum;
using Events;
using Game;
using Models.Layers;
using strange.extensions.command.impl;
using UnityEngine;

namespace cooking.controller
{
    public class InitLayersCommand : BaseCommand
    {
        [Inject] public LayerModel layerModel { get;set; }
        [Inject] public List<GameObject> Canvases{get;set;}
        
        public override void Execute()
        {
            base.Execute();
            
            foreach (var canvase in Canvases)
            {
                var layer = canvase.GetComponent<Layer>();
                
                if (layer != null)
                {
                    layerModel.Add(layer);
                }
            }
        }
    }
}