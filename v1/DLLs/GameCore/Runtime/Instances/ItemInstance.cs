using GameCore.Contexts;
using GameCore.Core.Abilities.Effects;
using GameCore.Core.Interfaces;
using GameCore.Core.Items;

namespace GameCore.Runtime.Instances
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

        public void Use(EffectContext effectContext)
        {
            foreach (var effect in EffectData)
            {
                effect.ApplyEffect(effectContext);
            }
        }
    }
}
