using GameCore.DungeonEntities.Monsters;
using GameCore.Partymember;
using GameRuntime.Contexts;
using GameRuntime.Events;
using GameRuntime.Events.Combat;

namespace GameSystems.Managers
{
    public class TargetSelectionManager
    {
        public PartymemberInstance PartymemberInstance { get; private set; } = null!;
        public MonsterInstance MonsterInstance { get; private set; } = null!;

        private GameContext _gameContext;

        public TargetSelectionManager(GameContext gameContext)
        {
            _gameContext = gameContext;

            _gameContext.EventManager.Subscribe<PartyMemberInstanceSelectedEvent>(OnPartyMemberInstanceSelected);
            _gameContext.EventManager.Subscribe<MonsterInstanceSelectedEvent>(OnMonsterInstanceSelected);
        }

        private void OnMonsterInstanceSelected(MonsterInstanceSelectedEvent e)
        {
            MonsterInstance = e.MonsterInstance;
            Console.WriteLine($"MonsterInstance selected: {e.MonsterInstance.Data.EntityType.ToString()}");
            Console.WriteLine("");

            if (PartymemberInstance != null)
            {
                Console.WriteLine($"PartymemberInstance: {PartymemberInstance.Data.Class.ToString()} is targeting MonsterInstance: {MonsterInstance.Data.EntityType.ToString()}");

                var combatContext = new CombatContext(PartymemberInstance, MonsterInstance);

                _gameContext.EventManager.Publish(new CombatStartedEvent(combatContext));

                Console.WriteLine("");
                return;
            }
        }

        private void OnPartyMemberInstanceSelected(PartyMemberInstanceSelectedEvent e)
        {
            PartymemberInstance = e.PartymemberInstance;
            Console.WriteLine($"PartymemberInstance selected: {e.PartymemberInstance.Data.Class.ToString()}");
            Console.WriteLine("");
        }
    }
}
