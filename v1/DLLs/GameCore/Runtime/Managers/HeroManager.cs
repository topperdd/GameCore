using GameCore.Contexts;
using GameCore.Core.Interfaces;
using GameCore.Runtime.Events;
using GameCore.Runtime.Events.Combat;
using GameCore.Runtime.Events.Creation;
using GameCore.Runtime.Factories;
using GameCore.Runtime.Instances;
using System.Net.Http.Headers;

namespace GameCore.Runtime.Managers
{
    public class HeroManager
    {
        private GameContext _gameContext { get; set; }

        public HeroInstance HeroInstance { get; private set; }
        private HeroFactory _heroFactory { get; set; }

        public HeroManager(GameContext gameContext)
        {
            _gameContext = gameContext;

            _heroFactory = new HeroFactory(gameContext);

            _gameContext.EventManager.Subscribe<HeroCreatedEvent>(OnHeroCreated);
            _gameContext.EventManager.Subscribe<HeroActiveAbilityUsedEvent>(OnHeroActiveAbilityUsed);

            _gameContext.EventManager.Subscribe<HeroGainedXpEvent>(OnHeroGainedXp);
            
            _gameContext.EventManager.Subscribe<DragonKilledEvent>(OnDragonKilled);
        }

        private void OnDragonKilled(DragonKilledEvent e)
        {
            GainXp(e.DragonWorthXp);
        }

        private void OnHeroGainedXp(HeroGainedXpEvent e)
        {
            GainXp(e.XpAmount);
        }

        public void AscendHero()
        {
            _heroFactory.CreateHeroInstance(HeroInstance.HeroData.AcendsToHeroId);
        }

        private void OnHeroActiveAbilityUsed(HeroActiveAbilityUsedEvent e)
        {
            var effectCtx = new EffectContext();
            effectCtx.GameContext = _gameContext;   

            foreach (var activeEffect in e.HeroInstance.ActiveEffects)
            {
                activeEffect.ApplyEffect(effectCtx);
            }
        }

        private void OnHeroCreated(HeroCreatedEvent e)
        {
            HeroInstance = e.HeroInstance;
        }

        private void GainXp(int amount)
        {
            if (HeroInstance.CurrentXp >= 5)
            {
                AscendHero();

                _gameContext.EventManager.Publish(new HeroAscendedEvent(HeroInstance));
            }
            else
            {
                var xpGainer = HeroInstance as IXpGainer;
                xpGainer.GainXp(amount);
            }
        }
    }
}
