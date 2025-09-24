using GameCore.Core.Interfaces;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Selection
{
    public class DragonFighterSelectedEvent
    {
        public IAttacker DragonFighter { get; private set; }

        public DragonFighterSelectedEvent(IAttacker dragonFighter)
        {
            DragonFighter = dragonFighter;
        }
    }
}
