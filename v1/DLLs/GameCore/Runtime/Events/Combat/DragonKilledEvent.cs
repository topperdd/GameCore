using GameCore.Core.Interfaces;

namespace GameCore.Runtime.Events.Combat
{
    public class DragonKilledEvent
    {
        public List<IAttacker> DragonFighters { get; private set; }
        public int DragonWorthXp { get; set; }

        public DragonKilledEvent(List<IAttacker> dragonFighters, int dragonWorthXp)
        {
            DragonFighters = dragonFighters ?? throw new ArgumentNullException(nameof(dragonFighters));
            DragonWorthXp = dragonWorthXp;
        }
    }
}
