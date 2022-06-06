using System;

namespace surf.context
{
    public class ContextView : strange.extensions.context.impl.ContextView
    {
        private void Awake()
        {
            context = new Context(this);
        }
    }
}