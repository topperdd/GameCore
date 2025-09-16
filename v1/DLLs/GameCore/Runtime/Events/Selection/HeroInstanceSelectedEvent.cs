using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Selection
{
    public class HeroInstanceSelectedEvent
    {
        public HeroInstance HeroInstance { get; set; }
        public HeroInstanceSelectedEvent(HeroInstance heroInstance)
        {
            HeroInstance = heroInstance;
        }
    }
}
