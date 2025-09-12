namespace GameCore.Abilities.Effects
{
    public class EffectData
    {
        public string EffectId { get; set; } = string.Empty;
        public EffectType Type { get; set; } 
        public int Value { get; set; }
    }
}

public enum EffectType
{
    Damage,
    Item
}
