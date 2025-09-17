using GameCore.Contexts;
using GameCore.Core;
using GameCore.Core.Abilities.Effects;
using GameCore.Core.Interfaces;
using GameCore.Runtime.Events.Items;

namespace GameCore.Runtime.Instances
{
    public class ItemInstance : IUseable
    {
        private List<IEffect> effects;

        private GameContext _gameContext { get; set; }

        public ItemData ItemData { get; private set; }
        public List<IEffect> EffectData { get; set; }

        public ItemInstance(ItemData itemData, List<IEffect> effectData, GameContext gameContext)
        {
            ItemData = itemData;
            EffectData = effectData;

            _gameContext = gameContext;
        }


        public void Use(EffectContext effectContext)
        {
            foreach (var effect in EffectData)
            {
                effect.ApplyEffect(effectContext);
            }

            _gameContext.EventManager.Publish(new ItemInstanceUsedEvent(this));
        }
    }
}
