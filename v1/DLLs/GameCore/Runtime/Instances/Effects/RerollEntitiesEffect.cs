using GameCore.Contexts;
using GameCore.Core.Abilities.Effects;
using GameCore.Runtime.Events;

namespace GameCore.Runtime.Instances.Effects
{
    internal class RerollEntitiesEffect : IEffect
    {
        public RerollEntitiesEffectData Data { get; private set; }

        public RerollEntitiesEffect(RerollEntitiesEffectData data) 
        {
            Data = data;
        }

        public void ApplyEffect(EffectContext effectContext)
        {
            effectContext.GameContext.EventManager.Publish(new RerollEntitiesEvent(effectContext.RerollContext));
        }
    }
}
