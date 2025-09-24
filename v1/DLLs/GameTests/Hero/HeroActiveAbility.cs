using GameCore.Runtime.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace GameTests.Hero
{
    public class HeroActiveAbility : TestBase
    {
        public HeroActiveAbility(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void ActivateHeroActiveAbility()
        {
            // Arrange
            GameContext.HeroFactory.CreateHeroInstance("Kampfmagier");

            GameContext.PartymemberFactory.CreatePartymemberInstance(PartymemberClass.Warrior);

            GameContext.DungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
            GameContext.DungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
            GameContext.DungeonEntityFactory.CreateMonsterInstance(MonsterType.Ooze);
            GameContext.DungeonEntityFactory.CreateMonsterInstance(MonsterType.Ooze);

            GameContext.DungeonEntityFactory.CreateLootInstance(LootType.Potion);
            GameContext.DungeonEntityFactory.CreateLootInstance(LootType.TreasureChest);


            // Act
            GameContext.EventManager.Publish(new HeroActiveAbilityUsedEvent(GameContext.HeroManager.HeroInstance));

            // Assert
            Assert.True(GameContext.DungeonManager.MonsterInstances.Count() == 0);
            Assert.True(GameContext.DungeonManager.LootInstances.Count() == 0);
        }

    }
}
