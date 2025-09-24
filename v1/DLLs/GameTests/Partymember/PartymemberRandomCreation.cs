using GameCore.Contexts;
using GameCore.Runtime.Factories;
using GameCore.Runtime.Instances;
using Xunit;
using Xunit.Abstractions;

namespace GameTests.Partymember
{
    public class PartymemberRandomCreation : TestBase
    {
        public PartymemberRandomCreation(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void PartymemberRandomCreation_DefaultTest()
        {

            // Arrange


            // Act
            GameContext.HeroFactory.CreateHeroInstance("ArkanerSchwertmeister");
            GameContext.PartymemberFactory.CreateRandomPartymemberGroup(7);


            // Assert
            LogList<PartymemberInstance>(GameContext.PartymemberManager.ActivePartymemberInstances);
        }
    }
}
