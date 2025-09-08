using GameCore.Abilities.AttackAbility;

namespace GameCore.Partymember
{
    public class PartymemberData
    {
        public PartymemberClass Class { get; set; }

        public IAttackAbility AttackAbility { get; set; } = null!;
    }
}
public enum PartymemberClass
{
    Warrior,
    Mage
}