using strange.extensions.command.impl;
using UnityEngine;

namespace cooking.controller
{
    public class ChangeSoundCommand : BaseCommand
    {
        [Inject] public bool soundEnabled { get; set; }

        public override void Execute()
        {
            base.Execute();
        }
    }
}