using GameCore.Contexts;
using GameCore.Core.Abilities.Effects;

namespace GameCore.Runtime.Instances.Effects
{
    public class DamageEffect : IEffect
    {
        public EffectData EffectData { get; private set; }
        public DamageEffect(EffectData effectData)
        {
            EffectData = effectData;
        }

        public void ApplyEffect(EffectContext effectContext)
        {
            foreach (var monster in effectContext.Targets)
            {
                monster.TakeDamage(EffectData.Value);
            }
        }
    }
}
