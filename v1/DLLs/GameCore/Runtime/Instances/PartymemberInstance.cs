using GameCore.Contexts;
using GameCore.Core;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Abilities.LootAbility;
using GameCore.Core.Abilities.RerollAbility;
using GameCore.Core.Interfaces;
using GameCore.Runtime.Events;

namespace GameCore.Runtime.Instances
{
    public class PartymemberInstance : IReviveable, IAttacker, ILooter
    {
        private GameContext _gameContext { get; set; }

        public PartymemberData Data { get; set; }
        public List<IAttackAbility> AttackAbilities { get; set; } = new List<IAttackAbility>();
        public ILootAbility LootAbility { get; set; } 
        public IRerollAbility RerollAbility { get; set; }
        public bool IsDead { get; set; }

        public PartymemberInstance(PartymemberData data, List<IAttackAbility> attackAbilities, ILootAbility lootAbility, IRerollAbility rerollAbility, GameContext gameContext)
        {
            _gameContext = gameContext;

            Data = data;
            AttackAbilities = attackAbilities;
            LootAbility = lootAbility;
            RerollAbility = rerollAbility;
        }

        public void Revive()
        {
            IsDead = false;
            Console.WriteLine($"{Data.Class} was revived!");

            _gameContext.EventManager.Publish(new PartymemberRevivedEvent(this));
        }
    }
}
