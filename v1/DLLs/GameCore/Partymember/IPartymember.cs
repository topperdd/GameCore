namespace GameCore.Partymember
{
    public interface IPartymember
    {
        public PartymemberClass Class { get; set; }
    }

    public enum PartymemberClass
    {
        Warrior,
        Mage
    }
}
