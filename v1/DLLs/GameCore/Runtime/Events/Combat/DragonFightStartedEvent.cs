using GameCore.Core.Interfaces;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Combat
{
    public class DragonFightStartedEvent
    {
        public List<IAttacker> Attackers { get; set; }
        public DragonInstance DragonInstance { get; set; }

        public DragonFightStartedEvent(List<IAttacker> attackers, DragonInstance dragonInstance)
        {
            Attackers = attackers;
            DragonInstance = dragonInstance;
        }
    }
}
