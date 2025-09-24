using GameCore.Contexts;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Factories;
using NuGet.Frameworks;
using Xunit;
using Xunit.Abstractions;

namespace GameTests.Combat
{
    public class KillSkeletons : TestBase
    {
        public KillSkeletons(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void KillSkeletons_DefaultTest()
        {

            // Arrange
            SetupFightScenario();


            // Act
            var partymember = GameContext.PartymemberManager.ActivePartymemberInstances.Where(q => q.Data.Class == PartymemberClass.Cleric).First();
            var monster = GameContext.DungeonManager.MonsterInstances.Where(q => q.Data.MonsterType == MonsterType.Skeleton).FirstOrDefault();

            GameContext.EventManager.Publish(new PartyMemberInstanceSelectedEvent(partymember));
            GameContext.EventManager.Publish(new MonsterInstanceSelectedEvent(monster));

            // Assert
            var remainingMonsters = GameContext.DungeonManager.MonsterInstances.Where(q => q.Data.MonsterType == MonsterType.Skeleton).ToList();

            foreach (var entity in GameContext.DungeonManager.MonsterInstances)
            {
                Log(entity.Data.MonsterType.ToString());
            }

            Assert.True(remainingMonsters.Count == 0);

        }
    }
}
