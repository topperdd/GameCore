namespace GameCore.Core.Items
{
    public class ItemData
    {
        public string ItemId { get; set; } = string.Empty;
        public List<string> EffectIds { get; set; } = new List<string>();
    }
}
