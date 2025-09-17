using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events
{
    public class HeroActiveAbilityUsedEvent
    {
        public HeroInstance HeroInstance { get; private set; }

        public HeroActiveAbilityUsedEvent(HeroInstance heroInstance)
        {
            HeroInstance = heroInstance;
        }
    }
}
