using GameCore.Contexts;
using GameCore.Runtime.Events;
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

            gameContext.EventManager.Subscribe<HeroCreatedEvent>(OnHeroCreated);
            gameContext.EventManager.Subscribe<HeroActiveAbilityUsedEvent>(OnHeroActiveAbilityUsed);

            gameContext.EventManager.Subscribe<HeroGainedXpEvent>(OnHeroGainedXp);
        }

        private void OnHeroGainedXp(HeroGainedXpEvent e)
        {
            if (HeroInstance.CurrentXp >= 5)
            {
                AscendHero();

                _gameContext.EventManager.Publish(new HeroAscendedEvent(HeroInstance));
            }
            else
            {
                Console.WriteLine($"Hero gained {e.XpAmount} XP. Current XP: {HeroInstance.CurrentXp}");
            }
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
    }
}
