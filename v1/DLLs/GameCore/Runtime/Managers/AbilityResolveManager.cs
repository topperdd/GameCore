using GameCore.Contexts;
using GameCore.Core.Interfaces;
using GameCore.Runtime.Events;
using GameCore.Runtime.Events.Combat;
using GameCore.Runtime.Events.Loot;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Managers
{
    public class AbilityResolveManager
    {
        private GameContext _gameContext;
        private CombatContext _combatContext;

        public AbilityResolveManager(GameContext gameContext)
        {
            _gameContext = gameContext;
            _gameContext.EventManager.Subscribe<CombatStartedEvent>(OnCombatStarted);
            _gameContext.EventManager.Subscribe<LootingStartedEvent>(OnLootingStarted);
        }

        private void OnLootingStarted(LootingStartedEvent e)
        {
            var lootCtx = new LootContext();
            lootCtx.Looter = e.Looter;
            lootCtx.LootInstance = e.LootInstance;

            e.Looter.LootAbility.ExecuteAbility(lootCtx);

            switch (e.Looter)
            {
                case PartymemberInstance:
                    _gameContext.EventManager.Publish(new PartymemberDiedEvent((PartymemberInstance)lootCtx.Looter));
                    Console.WriteLine("Partymember hat gelooted.");
                    break;

                case HeroInstance:
                    Console.WriteLine("Hero hat gelooted.");
                    break;
            }

            _gameContext.EventManager.Publish(new LootingFinishedEvent(lootCtx.LootInstance));
        }

        private void OnCombatStarted(CombatStartedEvent e)
        {
            _combatContext = e.CombatContext;

            ResolveAttackAbilityCombat();
        }

        private void ResolveAttackAbilityCombat()
        {
            var effectContext = new EffectContext();

            effectContext.DamageableTargets = _combatContext.MonsterInstances;

            _combatContext.AttackAbility.ExecuteAbility(effectContext);

            switch (_combatContext.Attacker)
            {
                case PartymemberInstance:
                    _gameContext.EventManager.Publish(new PartymemberDiedEvent((PartymemberInstance)_combatContext.Attacker));
                    Console.WriteLine("Partymember hat angegriffen.");
                    break;

                case HeroInstance:
                    Console.WriteLine("Hero hat angegriffen.");
                    break;
            }
        }
    }
}
