using GameCore.Contexts;
using GameCore.Core.Abilities.Effects;

namespace GameCore.Runtime.Instances.Effects
{
    public class PotionEffect : IEffect
    {
        public EffectData EffectData { get; private set; }

        public PotionEffect(EffectData effectData)
        {
            EffectData = effectData;
        }

        public void ApplyEffect(EffectContext effectContext)
        {
            //effectContext.PartymemberToRevive.Revive();
        }
    }
}
