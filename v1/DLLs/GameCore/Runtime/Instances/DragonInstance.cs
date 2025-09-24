using GameCore.Contexts;
using GameCore.Core.DungeonEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Runtime.Instances
{
    public class DragonInstance
    {
        private GameContext _gameContext { get; set; }

        public DragonData Data { get; set; }

        public int CurrentAttackerNeeded { get; set; }
        public int XpReward { get; set; }

        public DragonInstance(DragonData data, GameContext gameContext)
        {
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
            Data = data ?? throw new ArgumentNullException(nameof(data));
            CurrentAttackerNeeded = Data.AttackerNeeded;
            XpReward = Data.XpReward;
        }
    }
}
