using GameCore.Abilities.AttackAbility;

namespace GameCore.Partymember
{
    public class PartymemberData
    {
        public PartymemberClass Class { get; set; }

        public List<string> AttackAbilityIds { get; set; } = new List<string>();
    }
}
public enum PartymemberClass
{
    Warrior,
    Mage
}