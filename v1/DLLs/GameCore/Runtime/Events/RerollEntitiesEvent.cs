using GameCore.Contexts;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events
{
    public class RerollEntitiesEvent
    {
        public RerollContext Context { get; private set; }

        public RerollEntitiesEvent(RerollContext rerollContext)
        {
            Context = rerollContext;
        }
    }
}
