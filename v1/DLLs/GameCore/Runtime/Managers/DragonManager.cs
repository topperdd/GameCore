using GameCore.Contexts;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Interfaces;
using GameCore.Runtime.Events.Combat;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Managers
{
    public class DragonManager
    {
        private GameContext _gameContext { get; set; }
        private DragonInstance _dragonInstance { get; set; }
        private List<IAttacker> _dragonFighters { get; set; } 
        public DragonManager(GameContext gameContext)
        {
            _gameContext = gameContext;

            _gameContext.EventManager.Subscribe<DragonFightStartedEvent>(OnDragonFightStarted);
        }

        private void OnDragonFightStarted(DragonFightStartedEvent e)
        {
            _dragonFighters = e.Attackers;
            _dragonInstance = e.DragonInstance;

            ResolveDragonCombat(_dragonFighters, _dragonInstance);
        }

        private void ResolveDragonCombat(List<IAttacker> dragonFighters, DragonInstance dragonInstance)
        {
            var attacks = new List<IAttackAbility>();

            foreach (var fighter in dragonFighters)
            {
                foreach (var attackAbility in fighter.AttackAbilities)
                {
                    if (attackAbility.MonsterToKill != MonsterType.Any)
                    {
                        if (!attacks.Any(q => q.MonsterToKill == attackAbility.MonsterToKill))
                        {
                            attacks.Add(attackAbility);
                        }
                    }
                }
            }

            if (attacks.Count == dragonInstance.CurrentAttackerNeeded)
            {
                _gameContext.EventManager.Publish(new DragonKilledEvent(dragonFighters));
            }
            else
            {
                _gameContext.EventManager.Publish(new DragonNotKilledEvent());
            }
            
            ResetSelections();
        }

        private void ResetSelections()
        {
            _dragonFighters.Clear();
            _dragonInstance = null!;
        }
    }
}
