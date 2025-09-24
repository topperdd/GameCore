using GameCore.Contexts;
using GameCore.Runtime.Events.Combat;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Factories;
using GameCore.Runtime.Managers;
using Xunit;
using Xunit.Abstractions;

namespace GameTests.Items
{
    public class ItemUsage : TestBase
    {
        public ItemUsage(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void ItemUsage_DefaultTest()
        {
            // Arrange
            GameContext.ItemFactory.CreateItemInstance(ItemType.Potion);
            Log("Item created");

            SetupFightScenario();

            GameContext.EventManager.Publish(new PartymemberDiedEvent(GameContext.PartymemberManager.ActivePartymemberInstances[0]));
            Log("Partymember killed");


            // Act
            GameContext.EventManager.Publish(new PartyMemberInstanceSelectedEvent(GameContext.PartymemberManager.ActivePartymemberInstances[0]));
            GameContext.EventManager.Publish(new ItemInstanceSelectedEvent(GameContext.InventoryManager.ItemInstancesInInventory[0]));
            Log("Item used");

            foreach (var partymember in GameContext.PartymemberManager.ActivePartymemberInstances)
            {
                Console.WriteLine($"Partymember alive: {partymember.Data.Class}");
            }

            // Assert
            Assert.True(!GameContext.PartymemberManager.DeadPartymemberInstances.Any()); 
        }
    }
}
