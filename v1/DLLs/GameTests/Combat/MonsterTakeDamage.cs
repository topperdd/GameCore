using GameCore.Contexts;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Factories;
using Xunit;
using Xunit.Abstractions;


namespace GameTests.Combat
{
    public class MonsterTakeDamage : TestBase
    {
        public MonsterTakeDamage(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Actor_Should_Damage_Monster()
        {
            // Arrange
            HeroFactory.CreateHeroInstance("ArkanerSchwertmeister");
            PartymemberFactory.CreatePartymemberInstance(PartymemberClass.Warrior);
            DungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);

            var partymember = GameContext.PartymemberManager.ActivePartymemberInstances[0];
            var monster = GameContext.DungeonManager.MonsterInstances[0];
            var initialHealth = monster.CurrentHealth;

            // Act
            GameContext.EventManager.Publish(new PartyMemberInstanceSelectedEvent(partymember));
            GameContext.EventManager.Publish(new MonsterInstanceSelectedEvent(monster));

            // Assert
            Assert.True(monster.CurrentHealth < initialHealth);
        }
    }
}
