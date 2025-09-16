using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Interfaces;
using GameCore.Runtime.Instances;

namespace GameCore.Contexts
{
    public class CombatContext
    {
        public PartymemberInstance PartymemberInstance { get; set; } = null!;
        public HeroInstance HeroInstance { get; set; } = null!;
        public List<IDamageable> MonsterInstances { get; set; } = null!;
        public IAttackAbility? AttackAbility { get; set; } = null;
    }
}
