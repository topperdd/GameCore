
using GameCore.Contexts;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Interfaces;
using GameCore.Runtime.Events;
using GameCore.Runtime.Events.Combat;
using GameCore.Runtime.Events.Loot;
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
            ILooter looter = null!;

            if (PartymemberInstance != null)
            {
                looter = PartymemberInstance;
            }

            if (HeroInstance != null)
            {
                looter = HeroInstance;
            }

            _gameContext.EventManager.Publish(new LootingStartedEvent(e.LootInstance, looter));

            ResetSelection();
        }

        private void ResetSelection()
        {
            PartymemberInstance = null!;
            HeroInstance = null!;
            MonsterInstances.Clear();
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

                ResetSelection();
            }
        }

        private void OnMonsterInstanceSelected(MonsterInstanceSelectedEvent e)
        {
            IAttacker attacker = null!;

            if (PartymemberInstance != null)
            {
                attacker = PartymemberInstance;
            }

            if (HeroInstance != null)
            {
                attacker = HeroInstance;
            }

            var monsterType = e.MonsterInstance.Data.MonsterType;

            var attack = attacker.AttackAbilities.Find(attack => attack.MonsterToKill == monsterType);

            if (attack != null)
            {
                MonsterInstances = GetAllMonstersOfTheSameType(monsterType);
            }
            else
            {
                attack = attacker.AttackAbilities.Where(q => q.AbilityId == "AttackOneMonster").FirstOrDefault();

                MonsterInstances = new List<MonsterInstance> { e.MonsterInstance };
            }

            var combatContext = new CombatContext();

            combatContext.MonsterInstances = MonsterInstances.OfType<IDamageable>().ToList();

            combatContext.Attacker = attacker;
            combatContext.AttackAbility = attack;

            _gameContext.EventManager.Publish(new CombatStartedEvent(combatContext));

            Console.WriteLine("");

            ResetSelection();
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

            if (PartymemberInstance.Data.Class == PartymemberClass.Scroll)
            {
                //Fürs UI Targeting
                _gameContext.EventManager.Publish(new ScrollSelectedEvent());
            }
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
