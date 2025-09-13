namespace GameCore.Core.Interfaces
{
    public interface IReviveable
    {
        public bool IsDead { get; set; }
        public void Revive();
    }
}
