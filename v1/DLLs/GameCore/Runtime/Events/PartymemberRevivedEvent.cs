using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events
{
    public class PartymemberRevivedEvent
    {
        public PartymemberInstance Partymember { get; private set; }
        public PartymemberRevivedEvent(PartymemberInstance partymember)
        {
            Partymember = partymember;
        }
    }
}
