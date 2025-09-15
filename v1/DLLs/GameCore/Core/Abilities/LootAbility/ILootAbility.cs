using GameCore.Contexts;

namespace GameCore.Core.Abilities.LootAbility
{
    public interface ILootAbility
    {
        public string AbilityId { get; set; }
        public void ExecuteLoot(LootContext lootContext);
    }
}
