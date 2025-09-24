using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Combat
{
    public class DragonSelectedEvent
    {
        public DragonInstance DragonInstance { get; private set; }

        public DragonSelectedEvent(DragonInstance dragonInstance)
        {
            DragonInstance = dragonInstance;
        }   
    }
}
