using GameCore.Contexts;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Factories;
using Xunit;
using Xunit.Abstractions;

namespace GameTests.Looting
{
    public class PartymemberTreasureChestLooting : TestBase
    {
        public PartymemberTreasureChestLooting(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TreasureChestLooting_DefaultTest()
        {

            // Arrange
            SetupFightScenario();


            // Act
            GameContext.EventManager.Publish(new PartyMemberInstanceSelectedEvent(GameContext.PartymemberManager.ActivePartymemberInstances[0]));
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
