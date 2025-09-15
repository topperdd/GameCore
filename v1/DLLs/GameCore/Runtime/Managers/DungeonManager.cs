using GameCore.Contexts;
using GameCore.Runtime.Events.Combat;
using GameCore.Runtime.Events.Creation;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Managers
{
    public class DungeonManager
    {
        private GameContext _gameContext;

        public List<MonsterInstance> MonsterInstances { get; private set; } = new List<MonsterInstance>();
        public List<LootInstance> LootInstances { get; private set; } = new List<LootInstance>();

        public DungeonManager(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));

            _gameContext.EventManager.Subscribe<MonsterCreatedEvent>(OnMonsterCreated);
            _gameContext.EventManager.Subscribe<MonsterDiedEvent>(OnMonsterDied);

            _gameContext.EventManager.Subscribe<LootCreatedEvent>(OnLootCreated);
        }

        private void OnLootCreated(LootCreatedEvent e)
        {
            LootInstances.Add(e.LootInstance);
        }

        private void OnMonsterDied(MonsterDiedEvent e)
        {
            MonsterInstances.Remove(e.MonsterInstance);
        }

        private void OnMonsterCreated(MonsterCreatedEvent e)
        {
            MonsterInstances.Add(e.MonsterInstance);
        }

    }
}
