using GameCore.Contexts;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Interfaces;
using GameCore.Core.Partymember;
using GameCore.Runtime.Events;

namespace GameCore.Runtime.Instances
{
    public class PartymemberInstance : IReviveable
    {
        private GameContext _gameContext { get; set; }

        public PartymemberData Data { get; set; }
        public List<IAttackAbility> AttackAbilities { get; set; } = new List<IAttackAbility>();
        public bool IsDead { get; set; }

        public PartymemberInstance(PartymemberData data, List<IAttackAbility> attackAbilities, GameContext gameContext)
        {
            _gameContext = gameContext;

            Data = data;
            AttackAbilities = attackAbilities;
        }

        public void Revive()
        {
            IsDead = false;

            _gameContext.EventManager.Publish(new PartymemberRevivedEvent(this));
            Console.WriteLine($"{Data.Class} was revived!");
        }
    }
}
