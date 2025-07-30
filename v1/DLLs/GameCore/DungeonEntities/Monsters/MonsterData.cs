using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.DungeonEntities.Monsters
{
    public class MonsterData : IDungeonEntity, IMonster
    {
        public DungeonEntityType EntityType { get; set; }
        public MonsterType MonsterType { get; set; }
        public int MaxHealth { get; set; }
    }
}


