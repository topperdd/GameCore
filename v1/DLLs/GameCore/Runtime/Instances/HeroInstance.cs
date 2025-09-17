using GameCore.Contexts;
using GameCore.Core;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Abilities.Effects;
using GameCore.Core.Abilities.LootAbility;

namespace GameCore.Runtime.Instances
{
    public class HeroInstance
    {
        public HeroData HeroData { get; private set; }
        private GameContext _gameContext { get; set; }  

        public List<IAttackAbility> AttackAbilities { get; set; }
        public ILootAbility LootAbility { get; set; }
        public List<IEffect> PassiveEffects { get; set; } = new List<IEffect>();

        public HeroInstance(HeroData heroData, List<IAttackAbility> attackAbilities, ILootAbility lootAbility, List<IEffect> passiveEffects, GameContext gameContext)
        {
            gameContext = _gameContext;

            HeroData = heroData;
            AttackAbilities= attackAbilities;
            LootAbility = lootAbility;
            PassiveEffects = passiveEffects;
        }
    }
}
