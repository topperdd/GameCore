using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.DungeonEntities
{
    public interface IDungeonEntity
    {
        public DungeonEntityType EntityType { get; set; }
    }
}

public enum DungeonEntityType
{
    Monster
    //Loot,
    //Dragon
}
