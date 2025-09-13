using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Selection
{
    public class MonsterInstanceSelectedEvent
    {
        public MonsterInstance MonsterInstance { get; private set; }
        public MonsterInstanceSelectedEvent(MonsterInstance monsterInstance)
        {
            MonsterInstance = monsterInstance ?? throw new ArgumentNullException(nameof(monsterInstance), "MonsterInstance cannot be null.");
        }
    }
}
