using GameCore.Core.Abilities.AttackAbility;

namespace GameCore.Core
{
    public class HeroData
    {
        public string HeroId { get; set; }
        public string AcendsToHeroId { get; set; }
        public HeroType HeroType { get; set; }
        public int ExperienceToAscend { get; set; }

        public List<string> AttackAbilityIds { get; set; } = new List<string>();
        public string LootAbilityId { get; set; } 

        public List<string> ActiveEffectIds { get; set; } = new List<string>();
        public List<string> PassiveEffectIds { get; set; } = new List<string>();
    }
}
public enum HeroType
{
    Base,
    Ascended
}