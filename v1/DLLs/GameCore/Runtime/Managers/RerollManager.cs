using GameCore.Contexts;
using GameCore.Runtime.Events;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Managers
{
    public class RerollManager
    {
        private GameContext _gameContext { get; set; }

        public RerollManager(GameContext gameContext)
        {
            _gameContext = gameContext;

            _gameContext.EventManager.Subscribe<RerollEntitiesEvent>(OnRerollEntities);
        }

        private void OnRerollEntities(RerollEntitiesEvent e)
        {
            RerollEntities(e.Context.SelectedPartymembersToReroll);
            RerollEntities(e.Context.SelectedMonsterToReroll);
            RerollEntities(e.Context.SelectedLootToReroll);
        }

        private void RerollEntities<T>(List<T> entities)
        {
            var copiedList = entities.ToList();

            foreach (var entity in copiedList)
            {
                switch (entity)
                {
                    case PartymemberInstance:
                        _gameContext.PartymemberManager.ActivePartymemberInstances.Remove(entity as PartymemberInstance);
                        _gameContext.PartymemberFactory.CreatePartymemberInstance(PartymemberClass.Warrior);
                        break;

                    case MonsterInstance:
                        _gameContext.DungeonManager.MonsterInstances.Remove(entity as MonsterInstance);
                        _gameContext.DungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
                        break;

                    case LootInstance:
                        _gameContext.DungeonManager.LootInstances.Remove(entity as LootInstance);
                        _gameContext.DungeonEntityFactory.CreateLootInstance(LootType.TreasureChest);
                        break;
                }
            }
        }
    }
}
