using GameCore.Contexts;
using GameCore.Core.Abilities.Effects;

namespace GameCore.Runtime.Instances.Effects
{
    public class ReviveEffect : IEffect
    {
        public ReviveEffectData Data { get; set; }

        public ReviveEffect(ReviveEffectData data)
        {
            Data = data;
        }

        public void ApplyEffect(EffectContext effectContext)
        {
            effectContext.PartymemberToRevive.Revive();
        }
    }
}
