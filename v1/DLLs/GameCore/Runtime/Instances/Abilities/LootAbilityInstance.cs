using GameCore.Contexts;
using GameCore.Core.Abilities.LootAbility;

namespace GameCore.Runtime.Instances.Abilities
{
    public class LootAbilityInstance : ILootAbility
    {
        public LootAbilityData LootAbilityData { get; set; }

        public string AbilityId { get; set; }

        public LootAbilityInstance(LootAbilityData lootAbilityData)
        {
            LootAbilityData = lootAbilityData;
            AbilityId = LootAbilityData.AbilityId;
        }

        public void ExecuteAbility<T>(T context)
        {
            var lootContext = context as LootContext;   
            lootContext.LootInstance.Loot();
        }
    }
}
