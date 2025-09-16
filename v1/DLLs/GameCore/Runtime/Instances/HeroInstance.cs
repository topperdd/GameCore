using GameCore.Contexts;
using GameCore.Core;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Abilities.LootAbility;
using GameCore.Core.Interfaces;

namespace GameCore.Runtime.Instances
{
    public class HeroInstance
    {
        public HeroData HeroData { get; private set; }
        private GameContext _gameContext { get; set; }  

        public List<IAttackAbility> AttackAbilities { get; set; }
        public ILootAbility LootAbility { get; set; }

        public HeroInstance(HeroData heroData, List<IAttackAbility> attackAbilities, ILootAbility lootAbility, GameContext gameContext)
        {
            gameContext = _gameContext;

            HeroData = heroData;
            AttackAbilities= attackAbilities;
            LootAbility = lootAbility;
        }
    }
}
