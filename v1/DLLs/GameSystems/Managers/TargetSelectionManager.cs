using GameCore.Abilities.AttackAbility;
using GameCore.DungeonEntities.Monsters;
using GameCore.Interfaces;
using GameCore.Partymember;
using GameRuntime.Contexts;
using GameRuntime.Events;
using GameRuntime.Events.Combat;

namespace GameSystems.Managers
{
    public class TargetSelectionManager
    {
        public PartymemberInstance PartymemberInstance { get; private set; } = null!;
        public List<MonsterInstance> MonsterInstances { get; private set; } = new List<MonsterInstance>();

        private GameContext _gameContext;

        public TargetSelectionManager(GameContext gameContext)
        {
            _gameContext = gameContext;

            _gameContext.EventManager.Subscribe<PartyMemberInstanceSelectedEvent>(OnPartyMemberInstanceSelected);
            _gameContext.EventManager.Subscribe<MonsterInstanceSelectedEvent>(OnMonsterInstanceSelected);
        }

        private void OnMonsterInstanceSelected(MonsterInstanceSelectedEvent e)
        {
            if (PartymemberInstance != null)
            {
                var monsterType = e.MonsterInstance.Data.MonsterType;

                var attack = PartymemberInstance.AttackAbilities.Find(attack => attack.MonsterToKill == monsterType);

                if (attack != null)
                {
                    MonsterInstances = GetAllMonstersOfTheSameType(monsterType);
                }
                else
                {
                    attack = PartymemberInstance.AttackAbilities.Where(q => q.AbilityId == "AttackOneMonster").FirstOrDefault();

                    MonsterInstances = new List<MonsterInstance> { e.MonsterInstance };
                }

                Console.WriteLine($"PartymemberInstance: {PartymemberInstance.Data.Class.ToString()} is targeting MonsterType: {monsterType}");

                var combatContext = new CombatContext(PartymemberInstance, MonsterInstances, attack);

                _gameContext.EventManager.Publish(new CombatStartedEvent(combatContext));

                Console.WriteLine("");
                return;
            }
        }

        private List<MonsterInstance> GetAllMonstersOfTheSameType(MonsterType monsterType)
        {
            var result = new List<MonsterInstance>();

            foreach (var monster in _gameContext.DungeonManager.MonsterInstances)
            {
                if (monster.Data.MonsterType == monsterType)
                {
                    result.Add(monster);
                    Console.WriteLine($"MonsterInstance selected: {monster.Data.EntityType.ToString()}");
                }
                Console.WriteLine("");
            }

            return result;
        }

        private void OnPartyMemberInstanceSelected(PartyMemberInstanceSelectedEvent e)
        {
            PartymemberInstance = e.PartymemberInstance;
            Console.WriteLine($"PartymemberInstance selected: {e.PartymemberInstance.Data.Class.ToString()}");
            Console.WriteLine("");
        }
    }
}
