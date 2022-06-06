using strange.extensions.command.impl;
using strange.extensions.command.impl;

using UnityEngine;

namespace cooking.controller
{
    public class BaseCommand : strange.extensions.command.impl.Command
    {
        public override void Execute()
        {
            #if SHOW_LOGS
            Debug.Log(this.GetType().ToString());
            #endif
        }
    }
}