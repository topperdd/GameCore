using GameCore.DungeonEntities.Monsters;
using GameCore.Partymember;

namespace GameRuntime.Contexts
{
    public class CombatContext
    {
        public PartymemberInstance PartymemberInstance { get; private set; } = null!;
        public MonsterInstance MonsterInstance { get; private set; } = null!;

        public CombatContext(PartymemberInstance partymemberInstance, MonsterInstance monsterInstance)
        {
            PartymemberInstance = partymemberInstance ?? throw new ArgumentNullException(nameof(partymemberInstance), "PartymemberInstance cannot be null.");
            MonsterInstance = monsterInstance ?? throw new ArgumentNullException(nameof(monsterInstance), "MonsterInstance cannot be null.");
        }
    }
}
