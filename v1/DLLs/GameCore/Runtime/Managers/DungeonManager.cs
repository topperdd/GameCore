using GameCore.Contexts;
using GameCore.Runtime.Events.Combat;
using GameCore.Runtime.Events.Creation;
using GameCore.Runtime.Events.Loot;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Managers
{
    public class DungeonManager
    {
        private GameContext _gameContext;

        public List<MonsterInstance> MonsterInstances { get; private set; } = new List<MonsterInstance>();
        public List<LootInstance> LootInstances { get; private set; } = new List<LootInstance>();
        public int DragonCounter { get; set; } = 0;
        public DragonInstance DragonInstance { get; set; }

        public DungeonManager(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));

            _gameContext.EventManager.Subscribe<MonsterCreatedEvent>(OnMonsterCreated);
            _gameContext.EventManager.Subscribe<MonsterDiedEvent>(OnMonsterDied);

            _gameContext.EventManager.Subscribe<LootCreatedEvent>(OnLootCreated);

            _gameContext.EventManager.Subscribe<RemoveAllMonstersEvent>(OnRemoveAllMonsters);
            _gameContext.EventManager.Subscribe<RemoveAllLootEvent>(OnRemoveAllLoot);

            _gameContext.EventManager.Subscribe<LootingFinishedEvent>(OnLootingFinished);

            _gameContext.EventManager.Subscribe<DragonRolledEvent>(OnDragonRolled);
            _gameContext.EventManager.Subscribe<DragonCreatedEvent>(OnDragonCreated);
            _gameContext.EventManager.Subscribe<DragonKilledEvent>(OnDragonKilled);
        }

        private void OnDragonRolled(DragonRolledEvent e)
        {
            DragonCounter++;

            if (DragonCounter == 3)
            {
                _gameContext.DungeonEntityFactory.CreateDragonInstance();
            }
        }

        private void OnDragonKilled(DragonKilledEvent e)
        {
            DragonInstance = null!;
        }

        private void OnDragonCreated(DragonCreatedEvent e)
        {
            DragonInstance = e.DragonInstance;
        }

        private void OnLootingFinished(LootingFinishedEvent e)
        {
            LootInstances.Remove(e.LootInstance);
        }

        private void OnRemoveAllLoot(RemoveAllLootEvent e)
        {
            LootInstances.Clear();
        }

        private void OnRemoveAllMonsters(RemoveAllMonstersEvent e)
        {
            MonsterInstances.Clear();
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
