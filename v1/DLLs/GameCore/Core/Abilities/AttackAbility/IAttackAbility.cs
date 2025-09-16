using GameCore.Contexts;
using GameCore.Core.Interfaces;

namespace GameCore.Core.Abilities.AttackAbility
{
    public interface IAttackAbility : IAbility
    {
        public MonsterType MonsterToKill { get; }
    }
}
