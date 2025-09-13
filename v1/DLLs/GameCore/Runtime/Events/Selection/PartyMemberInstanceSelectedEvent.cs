using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Selection
{
    public class PartyMemberInstanceSelectedEvent
    {
        public PartymemberInstance PartymemberInstance { get; private set; }

        public PartyMemberInstanceSelectedEvent(PartymemberInstance partymemberInstance)
        {
            PartymemberInstance = partymemberInstance ?? throw new ArgumentNullException(nameof(partymemberInstance), "PartymemberInstance cannot be null.");
        }
    }
}
