using GameCore.Partymember;

namespace GameRuntime.Events
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
