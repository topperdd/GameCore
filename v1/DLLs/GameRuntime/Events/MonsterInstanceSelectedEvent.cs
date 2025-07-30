using GameCore.DungeonEntities.Monsters;

namespace GameRuntime.Events
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
