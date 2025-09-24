using GameCore.Contexts;
using GameCore.Runtime.Events.Combat;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Factories;
using Xunit;
using Xunit.Abstractions;

namespace GameTests.Combat
{
    public class KillDragon : TestBase
    {
        public KillDragon(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void KillDragon_DefaultTest()
        {

            // Arrange
            SetupDragonScenario();


            // Act
            //GameContext.EventManager.Publish(new DragonFighterSelectedEvent(GameContext.HeroManager.HeroInstance)); 
            foreach (var partymember in GameContext.PartymemberManager.ActivePartymemberInstances)
            {
                GameContext.EventManager.Publish(new DragonFighterSelectedEvent(partymember));
                Log(partymember.Data.Class.ToString() +  " für Drachenkampf ausgewählt!");
            }

            //handle drachenkampf
            GameContext.EventManager.Publish(new DragonSelectedEvent(GameContext.DungeonManager.DragonInstance));


            // Assert
            //drache besiegt
            //xp erhalten
            //loot erhalten
            var test = false;
            Assert.True(test);
        }
    }
}
