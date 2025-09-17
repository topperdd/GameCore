using GameCore.Core.Abilities.LootAbility;

namespace GameCore.Core.Interfaces
{
    public interface ILooter
    {
        public ILootAbility LootAbility { get; set; }
    }
}
