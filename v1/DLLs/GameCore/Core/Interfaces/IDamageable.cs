namespace GameCore.Core.Interfaces
{
    public interface IDamageable
    {
        public int CurrentHealth { get; set; }
        public void TakeDamage(int damageAmount);
    }
}
