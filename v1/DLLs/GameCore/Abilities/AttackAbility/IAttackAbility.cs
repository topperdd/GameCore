using GameCore.Interfaces;
using GameRuntime.Contexts;

namespace GameCore.Abilities.AttackAbility
{
    public interface IAttackAbility
    {
        public string AbilityId { get; }
        public MonsterType MonsterToKill { get; }
        public void ExecuteAttack(EffectContext effectContext);
    }
}
