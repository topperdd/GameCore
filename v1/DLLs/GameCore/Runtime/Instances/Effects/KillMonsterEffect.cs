using GameCore.Contexts;
using GameCore.Core.Abilities.Effects;
using GameCore.Core.Interfaces;

namespace GameCore.Runtime.Instances.Effects
{
    public class KillMonsterEffect : IEffect
    {
        int damageValue = 1;

        public DamageEffectData Data { get; set; }

        public KillMonsterEffect(DamageEffectData data)
        {
            Data = data;
        }

        public void ApplyEffect(EffectContext effectContext)
        {
            foreach (var monster in effectContext.DamageableTargets)
            {
                monster.TakeDamage(damageValue);
            }
        }
    }
}
