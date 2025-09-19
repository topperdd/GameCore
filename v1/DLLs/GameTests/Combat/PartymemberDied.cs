using GameCore.Runtime.Events.Selection;
using GameTests.Combat;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Abstractions;

namespace GameTests.Combat
{
    public class PartymemberDied : TestBase
    {
        public PartymemberDied(ITestOutputHelper output) : base(output)
        {
        }


        [Fact]
        public void SampleTest()
        {
            // Arrange
            HeroFactory.CreateHeroInstance("ArkanerSchwertmeister");

            PartymemberFactory.CreatePartymemberInstance(PartymemberClass.Warrior);
            PartymemberFactory.CreatePartymemberInstance(PartymemberClass.Mage);

            var partymember = GameContext.PartymemberManager.ActivePartymemberInstances[0];

            DungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
            DungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
            DungeonEntityFactory.CreateMonsterInstance(MonsterType.Ooze);
            DungeonEntityFactory.CreateMonsterInstance(MonsterType.Ooze);
            var monster = GameContext.DungeonManager.MonsterInstances.First();

            // Act
            GameContext.EventManager.Publish(new PartyMemberInstanceSelectedEvent(partymember));
            GameContext.EventManager.Publish(new MonsterInstanceSelectedEvent(monster));

            Assert.True(GameContext.PartymemberManager.ActivePartymemberInstances.Count == 1 &&
                GameContext.PartymemberManager.DeadPartymemberInstances.Count() == 1);
        }
    }
}
