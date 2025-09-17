using GameCore.Contexts;
using GameCore.Core.Abilities.Effects;
using GameCore.Runtime.Events.Creation;

namespace GameCore.Runtime.Instances.Effects
{
    public class RemoveAllMonstersEffect : IEffect
    {
        public RemoveAllMonstersData Data { get; set; }

        public RemoveAllMonstersEffect(RemoveAllMonstersData data)
        {
            Data = data;
        }

        public void ApplyEffect(EffectContext effectContext)
        {
            effectContext.GameContext.EventManager.Publish(new RemoveAllMonstersEvent());
        }
    }
}
