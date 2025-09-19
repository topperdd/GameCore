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
            HeroFactory.CreateHeroInstance("Kampfmagier");

            PartymemberFactory.CreatePartymemberInstance(PartymemberClass.Warrior);

            DungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
            DungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
            DungeonEntityFactory.CreateMonsterInstance(MonsterType.Ooze);
            DungeonEntityFactory.CreateMonsterInstance(MonsterType.Ooze);

            DungeonEntityFactory.CreateLootInstance(LootType.Potion);
            DungeonEntityFactory.CreateLootInstance(LootType.TreasureChest);


            // Act
            GameContext.EventManager.Publish(new HeroActiveAbilityUsedEvent(GameContext.HeroManager.HeroInstance));

            // Assert
            Assert.True(GameContext.DungeonManager.MonsterInstances.Count() == 0);
            Assert.True(GameContext.DungeonManager.LootInstances.Count() == 0);
        }

    }
}
