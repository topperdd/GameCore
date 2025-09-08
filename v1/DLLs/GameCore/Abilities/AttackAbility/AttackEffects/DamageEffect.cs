
using GameCore.Interfaces;

namespace GameCore.Abilities.AttackAbility.AttackEffects
{
    public class DamageEffect : IAttackEffect
    {
        public void ApplyEffect(IDamageable target)
        {
            target.TakeDamage(1);
        }
    }
}
