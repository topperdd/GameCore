namespace GameCore.Core
{
    public class PartymemberData
    {
        public PartymemberClass Class { get; set; }

        public List<string> AttackAbilityIds { get; set; } = new List<string>();
        public string LootAbilityId { get; set; } 
    }
}
public enum PartymemberClass
{
    Warrior,
    Mage
}