using GameCore.Abilities.Effects;
using GameCore.Interfaces;
using GameRuntime.Contexts;

namespace GameCore.Items
{
    public class ItemInstance : IUseable
    {
        public ItemData ItemData { get; private set; }
        public List<IEffect> EffectData { get; set; }

        public ItemInstance(ItemData itemData, List<IEffect> effectData)
        {
            ItemData = itemData;
            EffectData = effectData;
        }

        public void Use()
        {
            Console.WriteLine($"Item: {ItemData.ItemId} was used!");

            foreach (var effect in EffectData)
            {
                var effectContext = new EffectContext();

                effect.ApplyEffect(effectContext);
            }   
        }
    }
}
