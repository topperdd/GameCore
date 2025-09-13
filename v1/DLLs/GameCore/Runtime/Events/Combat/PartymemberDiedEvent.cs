using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Combat
{
    public class PartymemberDiedEvent
    {
        public PartymemberInstance PartymemberInstance { get; private set; }
        public PartymemberDiedEvent(PartymemberInstance partymemberInstance)
        {
            PartymemberInstance = partymemberInstance ?? throw new ArgumentNullException(nameof(partymemberInstance), "PartymemberInstance cannot be null.");
        }
    }
}
