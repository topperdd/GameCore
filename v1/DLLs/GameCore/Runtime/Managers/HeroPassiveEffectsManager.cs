using GameCore.Contexts;
using GameCore.Runtime.Events.Creation;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Managers
{
    public class HeroPassiveEffectsManager
    {
        private GameContext _gameContext { get; set; }
        private HeroInstance _heroInstance { get; set; }

        public HeroPassiveEffectsManager(GameContext gameContext)
        {
            _gameContext = gameContext;

            _gameContext.EventManager.Subscribe<BaseHeroCreatedEvent>(OnBaseHeroCreated);
            _gameContext.EventManager.Subscribe<PartymemberCreatedEvent>(OnPartymemberCreated);

        }

        private void OnBaseHeroCreated(BaseHeroCreatedEvent e)
        {
            _heroInstance = e.BaseHeroInstance;
        }

        private void OnPartymemberCreated(PartymemberCreatedEvent e)
        {
            var effectCtx = new EffectContext
            {
                GameContext = _gameContext,
                PartymemberToConvert = _gameContext.PartymemberManager.ActivePartymemberInstances
            };

            foreach (var passiveEffect in _heroInstance.PassiveEffects)
            {
                passiveEffect.ApplyEffect(effectCtx);
            }
        }
    }
}
