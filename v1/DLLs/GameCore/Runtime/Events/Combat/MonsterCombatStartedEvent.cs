using GameCore.Contexts;

namespace GameCore.Runtime.Events.Combat
{
    public class MonsterCombatStartedEvent
    {
        public MonsterCombatContext MonsterCombatContext { get; private set; }

        public MonsterCombatStartedEvent(MonsterCombatContext combatContext)
        {
            MonsterCombatContext = combatContext ?? throw new ArgumentNullException(nameof(combatContext), "CombatContext cannot be null.");
        }
    }
}
