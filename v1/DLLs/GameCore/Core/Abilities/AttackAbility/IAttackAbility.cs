using GameCore.Contexts;

namespace GameCore.Core.Abilities.AttackAbility
{
    public interface IAttackAbility
    {
        public string AbilityId { get; }
        public MonsterType MonsterToKill { get; }
        public void ExecuteAttack(EffectContext effectContext);
    }
}
