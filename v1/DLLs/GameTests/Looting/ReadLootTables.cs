using GameCore.Contexts;
using GameCore.Core.DungeonEntities.Loot;
using GameCore.Runtime.Factories;
using Xunit;
using Xunit.Abstractions;

namespace GameTests.Looting
{
    public class ReadLootTables : TestBase
    {
        public ReadLootTables(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void ReadLootTables_DefaultTest()
        {

            // Arrange


            // Act


            // Assert
            LogList<LootTableData>(GameContext.LootFactory.GetAllLootTables());
        }
    }
}
