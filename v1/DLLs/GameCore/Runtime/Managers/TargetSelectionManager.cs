using GameCore.Contexts;
using GameCore.Runtime.Events.Combat;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Managers
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
            _gameContext.EventManager.Subscribe<ItemInstanceSelectedEvent>(OnItemInstanceSelected);
            _gameContext.EventManager.Subscribe<LootInstanceSelectedEvent>(OnLootInstanceSelected);
        }

        private void OnLootInstanceSelected(LootInstanceSelectedEvent e)
        {
            if (PartymemberInstance != null)
            {
                var lootCtx = new LootContext();

                lootCtx.LootInstance = e.LootInstance;
                lootCtx.PartymemberInstance = PartymemberInstance;

                PartymemberInstance.LootAbility.ExecuteLoot(lootCtx);
            }
        }

        private void OnItemInstanceSelected(ItemInstanceSelectedEvent e)
        {
            if (PartymemberInstance != null)
            {
                var item = e.ItemInstance;
                Console.WriteLine($"Item in Inventory: {item.ItemData.ItemType}");

                var effectCtx = new EffectContext();

                switch (item.ItemData.TargetType)
                {
                    case TargetType.None:
                        break;

                    case TargetType.Partymember:
                        break;

                    case TargetType.DeadPartymember:
                        effectCtx.PartymemberToRevive = _gameContext.PartymemberManager.DeadPartymemberInstances[0];
                        break;

                    case TargetType.Monster:
                        break;

                    case TargetType.AllMonsters:
                        break;
                }

                item.Use(effectCtx);

                PartymemberInstance = null!;
            }
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

                PartymemberInstance = null!;
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

public enum TargetType
{
    None,
    Partymember,
    DeadPartymember,
    Monster,
    AllMonsters
}
