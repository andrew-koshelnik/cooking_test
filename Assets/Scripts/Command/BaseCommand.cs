using strange.extensions.command.impl;
using UnityEngine;

namespace surf.controller
{
    public class BaseCommand : Command
    {
        public override void Execute()
        {
            #if SHOW_LOGS
            Debug.Log(this.GetType().ToString());
            #endif
        }
    }
}