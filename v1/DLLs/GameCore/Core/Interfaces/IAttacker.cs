using GameCore.Core.Abilities.AttackAbility;

namespace GameCore.Core.Interfaces
{
    public interface IAttacker
    {
        public List<IAttackAbility> AttackAbilities { get; set; }
    }
}
