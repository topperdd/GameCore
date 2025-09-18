using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Creation
{
    public class HeroCreatedEvent
    {
        public HeroInstance HeroInstance { get; set; }

        public HeroCreatedEvent(HeroInstance heroInstance)
        {
            HeroInstance = heroInstance;
        }
    }
}
