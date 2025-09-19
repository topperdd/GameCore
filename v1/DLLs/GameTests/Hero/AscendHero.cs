using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace GameTests.Hero
{
    public class AscendHero : TestBase
    {
        public AscendHero(ITestOutputHelper output) : base(output)
        {
        }
        [Fact]
        public void AscendHeroClass()
        {
            // Arrange
            HeroFactory.CreateHeroInstance("ArkanerSchwertmeister");

            // Act
            GameContext.HeroManager.HeroInstance.GainXp(5);

            // Assert
            Assert.True(GameContext.HeroManager.HeroInstance.HeroData.HeroId == "Kampfmagier");
        }
    }
}
