using GameCore.Contexts;
using GameCore.Runtime.Events.Creation;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Managers
{
    public class HeroManager
    {
        private GameContext _gameContext { get; set; }

        public HeroInstance BaseHeroInstance { get; private set; }

        public HeroManager(GameContext gameContext)
        {
            _gameContext = gameContext;

            gameContext.EventManager.Subscribe<BaseHeroCreatedEvent>(OnBaseHeroCreated);
        }

        private void OnBaseHeroCreated(BaseHeroCreatedEvent e)
        {
            BaseHeroInstance = e.BaseHeroInstance;
        }
    }
}
