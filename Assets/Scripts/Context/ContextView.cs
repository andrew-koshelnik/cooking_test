using System;

namespace cooking.context
{
    public class ContextView : strange.extensions.context.impl.ContextView
    {
        private void Awake()
        {
            context = new Context(this);
        }
    }
}