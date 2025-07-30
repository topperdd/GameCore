using GameCore.DungeonEntities.Monsters;

namespace GameRuntime.Events.Creation
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
