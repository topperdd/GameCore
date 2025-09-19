using GameCore.Contexts;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Factories;
using GameCore.Runtime.Managers;
using System.Security.Cryptography;
using Xunit.Abstractions;

namespace GameTests.Hero
{
    public class HeroPassiveAbility : TestBase
    {
        public HeroPassiveAbility(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void ActivateHeroPassiveAbility()
        {
            // Arrange
            HeroFactory.CreateHeroInstance("ArkanerSchwertmeister");

            PartymemberFactory.CreatePartymemberInstance(PartymemberClass.Warrior);

            // Act
            foreach (var effect in GameContext.HeroManager.HeroInstance.PassiveEffects)
            {
                effect.ApplyEffect(new EffectContext
                {
                    GameContext = GameContext,
                    PartymemberToConvert = GameContext.PartymemberManager.ActivePartymemberInstances
                });

                Console.WriteLine($"Passive Hero Effect: {effect}");
            }

            // Assert
            var warriorAttacks = GameContext.PartymemberManager.ActivePartymemberInstances.FirstOrDefault().AttackAbilities;

            Assert.True(warriorAttacks.Count() == 3);  
        }

    }
}

