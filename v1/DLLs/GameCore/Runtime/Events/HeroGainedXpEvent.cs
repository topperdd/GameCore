using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events
{
    public class HeroGainedXpEvent
    {
        public int XpAmount { get; private set; }
        public HeroGainedXpEvent(int amountGained)
        {
            XpAmount = amountGained;
        }
    }
}
