using GameCore.Contexts;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Factories;
using GameTests;
using Xunit;

public class CombatTests : TestBase
{
    [Fact]
    public void Actor_Should_Damage_Monster()
    {
        // Arrange
        PartymemberFactory.CreatePartymemberInstance(PartymemberClass.Warrior);
        DungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
        HeroFactory.CreateHeroBaseInstance("ArkanerSchwertmeister");

        var hero = GameContext.PartymemberManager.ActivePartymemberInstances[0];
        var monster = GameContext.DungeonManager.MonsterInstances[0];
        var initialHealth = monster.CurrentHealth;

        // Act
        GameContext.EventManager.Publish(new HeroInstanceSelectedEvent(GameContext.HeroManager.BaseHeroInstance));
        GameContext.EventManager.Publish(new MonsterInstanceSelectedEvent(monster));

        // Assert
        Assert.True(monster.CurrentHealth < initialHealth);
    }
}