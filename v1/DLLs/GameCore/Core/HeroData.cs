using GameCore.Core.Abilities.AttackAbility;

namespace GameCore.Core
{
    public class HeroData
    {
        public string HeroId { get; set; }
        public HeroType HeroType { get; set; }
        public List<string> AttackAbilityIds { get; set; } = new List<string>();
        public string LootAbilityId { get; set; } 
    }
}
public enum HeroType
{
    Base,
    LevelUp
}