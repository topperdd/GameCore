using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Combat
{
    public class MonsterDiedEvent
    {
        public MonsterInstance MonsterInstance { get; private set; }

        public MonsterDiedEvent(MonsterInstance monsterInstance)
        {
            MonsterInstance = monsterInstance ?? throw new ArgumentNullException(nameof(monsterInstance), "MonsterInstance cannot be null.");
        }
    }
}
