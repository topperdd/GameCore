using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Creation
{
    public class BaseHeroCreatedEvent
    {
        public HeroInstance BaseHeroInstance { get; set; }

        public BaseHeroCreatedEvent(HeroInstance baseHeroInstance)
        {
            BaseHeroInstance = baseHeroInstance;
        }
    }
}
