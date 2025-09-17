
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events
{
    public class HeroAscendedEvent
    {
        public HeroInstance HeroInstance { get; private set; }
        public HeroAscendedEvent(HeroInstance heroInstance)
        {
            HeroInstance = heroInstance;
        }
    }
}
