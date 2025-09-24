using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace GameTests.Hero
{
    public class HeroGainXp : TestBase
    {
        public HeroGainXp(ITestOutputHelper output) : base(output)
        {
        }
        [Fact]
        public void HeroGainedXp()
        {
            // Arrange
            GameContext.HeroFactory.CreateHeroInstance("ArkanerSchwertmeister");

            // Act
            GameContext.HeroManager.HeroInstance.GainXp(4);

            // Assert
            Assert.True(GameContext.HeroManager.HeroInstance.CurrentXp == 4);
        }
    }
}
