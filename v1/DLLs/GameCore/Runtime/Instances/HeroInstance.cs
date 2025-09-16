using GameCore.Contexts;
using GameCore.Core;

namespace GameCore.Runtime.Instances
{
    public class HeroInstance
    {
        public HeroData HeroData { get; private set; }
        private GameContext _gameContext { get; set; }  

        public HeroInstance(HeroData heroData, GameContext gameContext)
        {
            HeroData = heroData;
            gameContext = _gameContext;
        }
    }
}
