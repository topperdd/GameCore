using GameCore.Contexts;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Factories;
using GameTests;
using Xunit;
using Xunit.Abstractions;

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
        GameContext.EventManager.Publish(new HeroInstanceSelectedEvent(GameContext.HeroManager.HeroInstance));
        GameContext.EventManager.Publish(new MonsterInstanceSelectedEvent(monster));

        // Assert
        Assert.True(monster.CurrentHealth < initialHealth);

        Console.WriteLine($"Monster health after attack: {monster.CurrentHealth}");
    }
}