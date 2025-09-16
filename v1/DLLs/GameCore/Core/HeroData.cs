namespace GameCore.Core
{
    public class HeroData
    {
        public string HeroId { get; set; }
        public HeroType HeroType { get; set; }
    }
}
public enum HeroType
{
    Base,
    LevelUp
}