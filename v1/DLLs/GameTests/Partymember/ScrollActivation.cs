using GameCore.Contexts;
using GameCore.Runtime.Events;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Factories;
using Xunit;
using Xunit.Abstractions;

namespace GameTests.Partymember
{
    public class ScrollActivation : TestBase
    {
        public ScrollActivation(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void ScrollActivation_DefaultTest()
        {

            // Arrange
            //- Erstelle Scrolls die als Partymember gelten
            SetupFightScenario();

            PartymemberFactory.CreatePartymemberInstance(PartymemberClass.Scroll);


            // Act
            //- Ausgabe aller gerollter Party/Dungeondice
            foreach (var item in GameContext.PartymemberManager.ActivePartymemberInstances)
            {
                if (item.Data.Class == PartymemberClass.Scroll)
                {
                    Log(item.Data.Class.ToString() + " - " + item.RerollAbility.AbilityId.ToString());
                }
            }

            //- Handle Inputselect
            GameContext.EventManager.Publish(new PartyMemberInstanceSelectedEvent(GameContext.PartymemberManager.ActivePartymemberInstances.Where(q => q.Data.Class == PartymemberClass.Scroll).First()));

            //- Auswahl an Party/Dungeondice
            Log("Auswahl der zu würfelenden Würfel");
            var partymember = GameContext.PartymemberManager.ActivePartymemberInstances;
            var monster = GameContext.DungeonManager.MonsterInstances;
            var loot = GameContext.DungeonManager.LootInstances;

            foreach (var item in partymember)
            {
                Log(item.Data.Class.ToString());
            }

            Log("-----------------");

            foreach (var item in monster)
            {
                Log(item.Data.MonsterType.ToString());
            }

            Log("-----------------");

            foreach (var item in loot)
            {
                Log(item.Data.LootType.ToString());
            }
            Log("-----------------");


            //- Reroll Party/Dungeondice
            var effectCtx = new EffectContext();
            effectCtx.GameContext = GameContext;
            effectCtx.RerollContext = new RerollContext(partymember, monster, loot);

            var rerollAbility = GameContext.TargetSelectionManager.PartymemberInstance.RerollAbility;
            rerollAbility.ExecuteAbility(effectCtx);


            //Assert
            Log("Reroll Ergebnis");
            var partymemberResult = GameContext.PartymemberManager.ActivePartymemberInstances;
            var monsterResult = GameContext.DungeonManager.MonsterInstances;
            var lootResult = GameContext.DungeonManager.LootInstances;

            foreach (var item in partymemberResult)
            {
                Log(item.Data.Class.ToString());
            }

            Log("-----------------");

            foreach (var item in monsterResult)
            {
                Log(item.Data.MonsterType.ToString());
            }

            Log("-----------------");

            foreach (var item in lootResult)
            {
                Log(item.Data.LootType.ToString());
            }
            Log("-----------------");
        }
    }
}
