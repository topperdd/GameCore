using GameCore.DungeonEntities.Monsters;
using GameCore.Interfaces;
using GameRuntime.Contexts;
using GameRuntime.Events;
using GameRuntime.Events.Combat;

namespace GameSystems.Managers
{
    public class CombatResolveManager
    {
        private GameContext _gameContext;
        private CombatContext _combatContext;

        public CombatResolveManager(GameContext gameContext)
        {
            _gameContext = gameContext;
            _gameContext.EventManager.Subscribe<CombatStartedEvent>(OnCombatStarted);
        }

        private void OnCombatStarted(CombatStartedEvent e)
        {
            _combatContext = e.CombatContext;

            ResolveMonsterCombat();
        }

        private void ResolveMonsterCombat()
        {
            var effectContext = new EffectContext();

            effectContext.Targets = _combatContext.MonsterInstances;

            _combatContext.AttackAbility.ExecuteAttack(effectContext);

            foreach (var target in effectContext.Targets)
            {
                var monster = target as MonsterInstance;

                _gameContext.EventManager.Publish(new MonsterDiedEvent(monster));
            }

            _gameContext.EventManager.Publish(new PartymemberDiedEvent(_combatContext.PartymemberInstance));
        }
    }
}
