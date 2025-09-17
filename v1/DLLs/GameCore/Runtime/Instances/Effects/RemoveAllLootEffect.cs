using GameCore.Contexts;
using GameCore.Core.Abilities.Effects;
using GameCore.Runtime.Events.Creation;

namespace GameCore.Runtime.Instances.Effects
{
    public class RemoveAllLootEffect : IEffect
    {
        public RemoveAllLootData Data { get; set; }

        public RemoveAllLootEffect(RemoveAllLootData data)
        {
            Data = data;
        }

        public void ApplyEffect(EffectContext effectContext)
        {
            effectContext.GameContext.EventManager.Publish(new RemoveAllLootEvent());
        }
    }
}
