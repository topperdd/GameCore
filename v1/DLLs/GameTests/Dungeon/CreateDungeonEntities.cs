using GameCore.Contexts;
using GameCore.Runtime.Factories;
using Xunit;
using Xunit.Abstractions;

namespace GameTests.Dungeon
{
    public class CreateDungeonEntities : TestBase
    {
        public CreateDungeonEntities(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void CreateDungeonEntities_DefaultTest()
        {

            // Arrange
            GameContext.DungeonEntityFactory.CreateRandomDungeon(7);


            // Act


            // Assert
            LogList(GameContext.DungeonManager.MonsterInstances);
            LogList(GameContext.DungeonManager.LootInstances);
            Log("DragonCounter: " + GameContext.DungeonManager.DragonCounter);

            if (GameContext.DungeonManager.DragonCounter == 3)
            {
                Assert.NotNull(GameContext.DungeonManager.DragonInstance);
            }
        }
    }
}
