
using GameCore.Contexts;

namespace GameCore.Core.Abilities.LootAbility
{
    public class LootAbilityData : ILootAbility
    {
        public string AbilityId { get; set; }

        public void ExecuteLoot(LootContext lootContext)
        {
            lootContext.LootInstance.Loot();
        }
    }
}
