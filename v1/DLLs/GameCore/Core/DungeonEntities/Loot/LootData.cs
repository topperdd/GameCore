using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Core.DungeonEntities.Loot
{
    public class LootData
    {
        public DungeonEntityType EntityType { get; set; }
        public LootType LootType { get; set; }
        public List<ItemType> ItemType { get; set; }
        public string LootTableId { get; set; }
    }
}

public enum LootType
{
    TreasureChest,
    Potion
}
