
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Creation
{
    public class DragonCreatedEvent
    {
        public DragonInstance DragonInstance { get; private set; }

        public DragonCreatedEvent(DragonInstance dragonInstance)
        {
            DragonInstance = dragonInstance;
        }
    }
}
