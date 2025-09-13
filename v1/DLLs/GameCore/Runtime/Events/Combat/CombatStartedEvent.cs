using GameCore.Contexts;

namespace GameCore.Runtime.Events.Combat
{
    public class CombatStartedEvent
    {
        public CombatContext CombatContext { get; private set; }

        public CombatStartedEvent(CombatContext combatContext)
        {
            CombatContext = combatContext ?? throw new ArgumentNullException(nameof(combatContext), "CombatContext cannot be null.");
        }
    }
}
