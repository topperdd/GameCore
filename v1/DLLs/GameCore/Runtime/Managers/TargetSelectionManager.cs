
using GameCore.Contexts;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Interfaces;
using GameCore.Runtime.Events.Combat;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Managers
{
    public class TargetSelectionManager
    {
        public PartymemberInstance PartymemberInstance { get; private set; } = null!;
        public HeroInstance HeroInstance { get; private set; } = null!;
        public List<MonsterInstance> MonsterInstances { get; private set; } = new List<MonsterInstance>();


        private GameContext _gameContext;

        public TargetSelectionManager(GameContext gameContext)
        {
            _gameContext = gameContext;

            _gameContext.EventManager.Subscribe<PartyMemberInstanceSelectedEvent>(OnPartyMemberInstanceSelected);
            _gameContext.EventManager.Subscribe<MonsterInstanceSelectedEvent>(OnMonsterInstanceSelected);
            _gameContext.EventManager.Subscribe<ItemInstanceSelectedEvent>(OnItemInstanceSelected);
            _gameContext.EventManager.Subscribe<LootInstanceSelectedEvent>(OnLootInstanceSelected);
            _gameContext.EventManager.Subscribe<HeroInstanceSelectedEvent>(OnHeroInstanceSelected);
        }

        private void OnHeroInstanceSelected(HeroInstanceSelectedEvent e)
        {
            HeroInstance = e.HeroInstance;
        }

        private void OnLootInstanceSelected(LootInstanceSelectedEvent e)
        {
            if (PartymemberInstance != null)
            {
                var lootCtx = new LootContext();

                lootCtx.LootInstance = e.LootInstance;
                lootCtx.PartymemberInstance = PartymemberInstance;

                PartymemberInstance.LootAbility.ExecuteAbility(lootCtx);
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
            var attacks = new List<IAttackAbility>();

            if (PartymemberInstance != null)
            {
                attacks = PartymemberInstance.AttackAbilities;
            }

            if (HeroInstance != null)
            {
                attacks = HeroInstance.AttackAbilities;
            }

            var monsterType = e.MonsterInstance.Data.MonsterType;

            var attack = attacks.Find(attack => attack.MonsterToKill == monsterType);

            if (attack != null)
            {
                MonsterInstances = GetAllMonstersOfTheSameType(monsterType);
            }
            else
            {
                attack = attacks.Where(q => q.AbilityId == "AttackOneMonster").FirstOrDefault();

                MonsterInstances = new List<MonsterInstance> { e.MonsterInstance };
            }

            //Console.WriteLine($"PartymemberInstance: {PartymemberInstance.Data.Class.ToString()} is targeting MonsterType: {monsterType}");

            var combatContext = new CombatContext();

            combatContext.MonsterInstances = MonsterInstances.OfType<IDamageable>().ToList();
            combatContext.PartymemberInstance = PartymemberInstance;
            combatContext.AttackAbility = attack;
            combatContext.HeroInstance = HeroInstance;

            _gameContext.EventManager.Publish(new CombatStartedEvent(combatContext));

            Console.WriteLine("");

            PartymemberInstance = null!;
            HeroInstance = null!;
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
