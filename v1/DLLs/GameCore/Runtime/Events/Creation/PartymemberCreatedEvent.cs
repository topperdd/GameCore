using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Creation
{
    public class PartymemberCreatedEvent
    {
        public PartymemberInstance PartymemberInstance { get; private set; }
        public PartymemberCreatedEvent(PartymemberInstance partymemberInstance)
        {
            PartymemberInstance = partymemberInstance;
        }
    }
}
