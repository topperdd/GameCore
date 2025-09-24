using GameCore.Contexts;
using GameCore.Runtime.Events;
using GameCore.Runtime.Events.Combat;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Factories;
using GameTests.Hero;
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
            var heroXpBeforeFight = GameContext.HeroManager.HeroInstance.CurrentXp;


            // Act
            //GameContext.EventManager.Publish(new DragonFighterSelectedEvent(GameContext.HeroManager.HeroInstance)); 
            foreach (var partymember in GameContext.PartymemberManager.ActivePartymemberInstances)
            {
                GameContext.EventManager.Publish(new DragonFighterSelectedEvent(partymember));
                Log(partymember.Data.Class.ToString() +  " für Drachenkampf ausgewählt!");
            }

            //handle drachenkampf
            GameContext.EventManager.Publish(new DragonSelectedEvent(GameContext.DungeonManager.DragonInstance));

            Log("Xp gained: " + GameContext.HeroManager.HeroInstance.CurrentXp.ToString());


            // Assert
            Assert.True(GameContext.DungeonManager.DragonInstance == null);
            Assert.True(GameContext.HeroManager.HeroInstance.CurrentXp > heroXpBeforeFight);
        }
    }
}
