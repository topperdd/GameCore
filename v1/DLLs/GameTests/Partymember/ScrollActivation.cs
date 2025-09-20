using GameCore.Contexts;
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


            //- Auswahl an Party/Dungeondice
            //- Reroll Party/Dungeondice
            //- Kill Partymember


            // Assert
            //- Ausgewählter Partydie ist tot
            //- Ausgabe aller Party/Dungeondice -> sollten anders sein als ausgang
        }
    }
}
