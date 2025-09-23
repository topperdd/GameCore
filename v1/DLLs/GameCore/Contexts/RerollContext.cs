using GameCore.Runtime.Instances;
using System.Threading;

namespace GameCore.Contexts
{
    public class RerollContext
    {
        public List<PartymemberInstance> SelectedPartymembersToReroll { get; private set; } = new List<PartymemberInstance>();
        public List<MonsterInstance> SelectedMonsterToReroll { get; private set; } = new List<MonsterInstance>();
        public List<LootInstance> SelectedLootToReroll { get; private set; }

        public RerollContext(List<PartymemberInstance> partymembers, List<MonsterInstance> monster, List<LootInstance> loot)
        {
            SelectedPartymembersToReroll = partymembers;
            SelectedMonsterToReroll = monster;
            SelectedLootToReroll = loot;
        }
    }
}
