using GameCore.Contexts;
using GameCore.Runtime.Events.Combat;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Managers
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

            effectContext.DamageableTargets = _combatContext.MonsterInstances;

            _combatContext.AttackAbility.ExecuteAttack(effectContext);

            _gameContext.EventManager.Publish(new PartymemberDiedEvent(_combatContext.PartymemberInstance));
        }
    }
}
