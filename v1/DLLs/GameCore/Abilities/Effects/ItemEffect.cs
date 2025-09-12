using GameRuntime.Contexts;

namespace GameCore.Abilities.Effects
{
    public class ItemEffect : IEffect
    {
        public EffectData EffectData { get; private set; }

        public ItemEffect(EffectData effectData)
        {
            EffectData = effectData;
        }

        public void ApplyEffect(EffectContext effectContext)
        {
            Console.WriteLine("ItemEffect applied!");
        }
    }
}
