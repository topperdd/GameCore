using GameCore.Contexts;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Factories;
using Xunit;
using Xunit.Abstractions;

namespace GameTests.Looting
{
    public class HeroTreasureChestLooting : TestBase
    {
        public HeroTreasureChestLooting(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void HeroTreasureChestLooting_DefaultTest()
        {
            // Arrange
            SetupFightScenario();

            // Act
            GameContext.EventManager.Publish(new HeroInstanceSelectedEvent(GameContext.HeroManager.HeroInstance));
            GameContext.EventManager.Publish(new LootInstanceSelectedEvent(GameContext.DungeonManager.LootInstances[0]));

            foreach (var item in GameContext.InventoryManager.ItemInstancesInInventory)
            {
                Log($"Item in Inventory: {item.ItemData.ItemType}");
            }

            // Assert
            Assert.Empty(GameContext.DungeonManager.LootInstances);
            Assert.NotEmpty(GameContext.InventoryManager.ItemInstancesInInventory);
        }
    }
}
