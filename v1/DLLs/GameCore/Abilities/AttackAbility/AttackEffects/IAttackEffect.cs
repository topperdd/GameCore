using GameCore.Interfaces;

namespace GameCore.Abilities.AttackAbility.AttackEffects
{
    public interface IAttackEffect
    {
        void ApplyEffect(IDamageable target);
    }
}
