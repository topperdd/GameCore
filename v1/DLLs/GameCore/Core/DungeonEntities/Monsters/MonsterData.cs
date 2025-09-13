using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Core.DungeonEntities.Monsters
{
    public class MonsterData
    {
        public DungeonEntityType EntityType { get; set; }
        public MonsterType MonsterType { get; set; }
        public int MaxHealth { get; set; }
    }
}


public enum MonsterType
{
    Goblin,
    Ooze,
    Any
}

public enum DungeonEntityType
{
    Monster
    //Loot,
    //Dragon
}