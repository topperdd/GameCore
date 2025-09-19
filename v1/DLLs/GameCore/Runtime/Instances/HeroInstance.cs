using GameCore.Contexts;
using GameCore.Core;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Abilities.Effects;
using GameCore.Core.Abilities.LootAbility;
using GameCore.Core.Interfaces;
using GameCore.Runtime.Events;

namespace GameCore.Runtime.Instances
{
    public class HeroInstance : IAttacker, ILooter, IXpGainer
    {
        public HeroData HeroData { get; private set; }
        private GameContext _gameContext { get; set; }

        public int CurrentXp { get; private set; } = 0;

        public List<IAttackAbility> AttackAbilities { get; set; }
        public ILootAbility LootAbility { get; set; }
        public List<IEffect> ActiveEffects { get; set; } = new List<IEffect>();
        public List<IEffect> PassiveEffects { get; set; } = new List<IEffect>();

        public HeroInstance(HeroData heroData, List<IAttackAbility> attackAbilities, ILootAbility lootAbility, List<IEffect> passiveEffects, List<IEffect> activeEffects, GameContext gameContext)
        {
            _gameContext = gameContext;

            HeroData = heroData;
            AttackAbilities= attackAbilities;
            LootAbility = lootAbility;
            ActiveEffects = activeEffects;
            PassiveEffects = passiveEffects;
        }

        public void GainXp(int amount)
        {
            CurrentXp+= amount;

            if (CurrentXp >= 5)
            {
                _gameContext.HeroManager.AscendHero();

            }
        }
    }
}
