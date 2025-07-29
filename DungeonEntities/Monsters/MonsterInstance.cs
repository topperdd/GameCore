using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.DungeonEntities.Monsters
{
    public class MonsterInstance
    {
        public MonsterData Data { get; set; }

        public MonsterInstance(MonsterData monsterData)
        {
            Data = monsterData;
        }
    }
}
