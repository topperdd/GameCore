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

            ResolveCombat();
        }

        private void ResolveCombat()
        {
            _combatContext.PartymemberInstance.Data.AttackAbility.ExecuteAttack(_combatContext.MonsterInstance);
            Console.WriteLine($"Monster Type: {_combatContext.MonsterInstance.Data.MonsterType}, CurrentLife: {_combatContext.MonsterInstance.CurrentHealth}");
            Console.WriteLine("");   
        }
    }
}
