using GameCore.Contexts;
using GameCore.Core.DungeonEntities.Monsters;
using GameCore.Core.Interfaces;
using GameCore.Runtime.Events.Combat;

namespace GameCore.Runtime.Instances
{
    public class MonsterInstance : IDamageable
    {
        public MonsterData Data { get; set; }
        public int CurrentHealth { get; set; }

        private GameContext _gameContext { get; set; }

        public MonsterInstance(MonsterData monsterData, GameContext gameContext)
        {
            _gameContext = gameContext;

            Data = monsterData;
            CurrentHealth = monsterData.MaxHealth;
        }

        public void TakeDamage(int damageAmount)
        {
            CurrentHealth -= damageAmount;

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;

                Console.WriteLine("");
                Console.WriteLine($"Monster of type {Data.MonsterType} has been defeated.");

                _gameContext.EventManager.Publish(new MonsterDiedEvent(this));
            }
        }
    }
}
