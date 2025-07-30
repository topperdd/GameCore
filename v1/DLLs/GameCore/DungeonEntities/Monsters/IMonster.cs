using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.DungeonEntities.Monsters
{
    public interface IMonster
    {
        public MonsterType MonsterType { get; set; }
        public int MaxHealth { get; set; }
    }
}

public enum MonsterType
{
    Goblin
}