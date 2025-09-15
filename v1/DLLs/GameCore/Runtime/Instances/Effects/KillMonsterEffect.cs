using GameCore.Contexts;
using GameCore.Core.Abilities.Effects;

namespace GameCore.Runtime.Instances.Effects
{
    public class KillMonsterEffect : IEffect
    {
        public EffectData EffectData { get; private set; }
        public KillMonsterEffect(EffectData effectData)
        {
            EffectData = effectData;
        }

        public void ApplyEffect(EffectContext effectContext)
        {
            foreach (var monster in effectContext.DamageableTargets)
            {
                monster.TakeDamage(EffectData.Value);
            }
        }
    }
}
