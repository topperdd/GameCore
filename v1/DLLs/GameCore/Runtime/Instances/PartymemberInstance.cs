using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Interfaces;
using GameCore.Core.Partymember;

namespace GameCore.Runtime.Instances
{
    public class PartymemberInstance : IReviveable
    {
        public PartymemberData Data { get; set; }
        public List<IAttackAbility> AttackAbilities { get; set; } = new List<IAttackAbility>();
        public bool IsDead { get; set; }

        public PartymemberInstance(PartymemberData data, List<IAttackAbility> attackAbilities)
        {
            Data = data;
            AttackAbilities = attackAbilities;
        }

        public void Revive()
        {
            IsDead = false;
            Console.WriteLine($"{Data.Class} was revived!");
        }
    }
}
