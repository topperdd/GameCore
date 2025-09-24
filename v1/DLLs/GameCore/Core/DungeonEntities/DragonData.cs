using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Core.DungeonEntities
{
    public class DragonData
    {
        DungeonEntityType EntityType { get; set; }
        public int AttackerNeeded { get; set; }
        public int XpReward { get; set; }

    }
}
