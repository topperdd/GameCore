using GameCore.Core.Interfaces;

namespace GameCore.Runtime.Events.Combat
{
    public class DragonKilledEvent
    {
        public List<IAttacker> DragonFighters { get; private set; }

        public DragonKilledEvent(List<IAttacker> dragonFighters)
        {
            DragonFighters = dragonFighters ?? throw new ArgumentNullException(nameof(dragonFighters));
        }
    }
}
