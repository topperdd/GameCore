using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Creation
{
    public class MonsterCreatedEvent
    {
        public MonsterInstance MonsterInstance { get; private set; }
        public MonsterCreatedEvent(MonsterInstance monsterInstance)
        {
            MonsterInstance = monsterInstance ?? throw new ArgumentNullException(nameof(monsterInstance), "MonsterInstance cannot be null.");
        }
    }
}
