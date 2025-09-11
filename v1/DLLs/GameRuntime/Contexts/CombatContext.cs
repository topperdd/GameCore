using GameCore.DungeonEntities.Monsters;
using GameCore.Interfaces;
using GameCore.Partymember;

namespace GameRuntime.Contexts
{
    public class CombatContext
    {
        public PartymemberInstance PartymemberInstance { get; private set; } = null!;
        public List<IDamageable> MonsterInstances { get; private set; } = null!;

        public CombatContext(PartymemberInstance partymemberInstance, List<MonsterInstance> monsterInstance)
        {
            PartymemberInstance = partymemberInstance ?? throw new ArgumentNullException(nameof(partymemberInstance), "PartymemberInstance cannot be null.");
            MonsterInstances = monsterInstance.OfType<IDamageable>().ToList();
        }
    }
}
