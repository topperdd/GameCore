namespace GameCore.Core.Items
{
    public class ItemData
    {
        public ItemType ItemType { get; set; }
        public TargetType TargetType { get; set; }
        public List<string> EffectIds { get; set; } = new List<string>();
    }
}

public enum ItemType
{
    Potion
}
