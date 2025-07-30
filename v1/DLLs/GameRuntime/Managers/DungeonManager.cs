using GameCore.DungeonEntities.Monsters;
using GameRuntime.Contexts;
using GameRuntime.Events.Creation;

namespace GameRuntime.Managers
{
    public class DungeonManager
    {
        private GameContext _gameContext;

        public List<MonsterInstance> MonsterInstances { get; private set; } = new List<MonsterInstance>();

        public DungeonManager(GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            _gameContext.EventManager.Subscribe<MonsterCreatedEvent>(OnMonsterCreated);
        }

        private void OnMonsterCreated(MonsterCreatedEvent e)
        {
            MonsterInstances.Add(e.MonsterInstance);
        }

    }
}
