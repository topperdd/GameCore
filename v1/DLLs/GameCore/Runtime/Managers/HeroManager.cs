using GameCore.Contexts;
using GameCore.Runtime.Events;
using GameCore.Runtime.Events.Creation;
using GameCore.Runtime.Instances;
using System.Net.Http.Headers;

namespace GameCore.Runtime.Managers
{
    public class HeroManager
    {
        private GameContext _gameContext { get; set; }

        public HeroInstance HeroInstance { get; private set; }

        public HeroManager(GameContext gameContext)
        {
            _gameContext = gameContext;

            gameContext.EventManager.Subscribe<BaseHeroCreatedEvent>(OnBaseHeroCreated);
            gameContext.EventManager.Subscribe<HeroActiveAbilityUsedEvent>(OnHeroActiveAbilityUsed);

            gameContext.EventManager.Subscribe<HeroAscendedEvent>(OnHeroAscended);
        }

        private void OnHeroAscended(HeroAscendedEvent e)
        {
            
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

        private void OnBaseHeroCreated(BaseHeroCreatedEvent e)
        {
            HeroInstance = e.BaseHeroInstance;
        }
    }
}
