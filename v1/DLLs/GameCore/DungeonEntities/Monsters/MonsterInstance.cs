using GameCore.Interfaces;

namespace GameCore.DungeonEntities.Monsters
{
    public class MonsterInstance : IDamageable
    {
        public MonsterData Data { get; set; }
        public int CurrentHealth { get; set; }

        public MonsterInstance(MonsterData monsterData)
        {
            Data = monsterData;
            CurrentHealth = monsterData.MaxHealth;
        }

        public void TakeDamage(int damageAmount)
        {
            CurrentHealth -= damageAmount;

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                Console.WriteLine($"Monster of type {Data.MonsterType} has been defeated.");
                Console.WriteLine("");


            }
        }
    }
}
