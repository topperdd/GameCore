#nullable disable

using GameCore.Contexts;
using GameCore.Runtime.Events;
using GameCore.Runtime.Events.Selection;
using GameCore.Runtime.Factories;
using GameCore.Runtime.Managers;


var gameContext = new GameContext();
var targetSelectionManager = new TargetSelectionManager(gameContext);
var abilityResolveManager = new AbilityResolveManager(gameContext);

var partymemberFactory = new PartymemberFactory(gameContext);
var itemFactory = new ItemFactory(gameContext); 
var heroFactory = new HeroFactory(gameContext);

#region HeroCreation
Console.WriteLine($"Hero creation:");
heroFactory.CreateHeroInstance("ArkanerSchwertmeister");
//gameContext.EventManager.Publish(new HeroAscendedEvent(gameContext.HeroManager.HeroInstance));
//heroFactory.CreateHeroBaseInstance("Kampfmagier");

Console.WriteLine($"Current active Hero: {gameContext.HeroManager.HeroInstance.HeroData.HeroId}");
#endregion

partymemberFactory.CreatePartymemberInstance(PartymemberClass.Warrior);
partymemberFactory.CreatePartymemberInstance(PartymemberClass.Mage);


var dungeonEntityFactory = new DungeonEntityFactory(gameContext);
dungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
dungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
dungeonEntityFactory.CreateMonsterInstance(MonsterType.Ooze);
dungeonEntityFactory.CreateMonsterInstance(MonsterType.Ooze);


#region HeroPassiveAbility
foreach (var effect in gameContext.HeroManager.HeroInstance.PassiveEffects)
{
    effect.ApplyEffect(new EffectContext
    {
        GameContext = gameContext,
        PartymemberToConvert = gameContext.PartymemberManager.ActivePartymemberInstances
    });

    Console.WriteLine($"Passive Hero Effect: {effect}");
}
#endregion

#region HeroActiveAbility
gameContext.EventManager.Publish(new HeroActiveAbilityUsedEvent(gameContext.HeroManager.HeroInstance));
Console.WriteLine(gameContext.DungeonManager.MonsterInstances.Count);
Console.WriteLine(gameContext.DungeonManager.LootInstances.Count);
#endregion


#region HeroGainXp
gameContext.HeroManager.HeroInstance.GainXp(5);

Console.WriteLine($"Current active Hero: {gameContext.HeroManager.HeroInstance.HeroData.HeroId}");
Console.WriteLine();

#endregion

foreach (var partymember in gameContext.PartymemberManager.ActivePartymemberInstances)
{
    Console.WriteLine($"Partymember Class: {partymember.Data.Class.ToString()}");
}
Console.WriteLine("");
Console.WriteLine("-------------------------------------------------------------------------------------------------------");

//#region Fight
//Console.WriteLine("Fighting:");
//foreach (var monster in gameContext.DungeonManager.MonsterInstances)
//{
//    Console.WriteLine($"Monster Type: {monster.Data.MonsterType}, CurrentLife: {monster.CurrentHealth}");
//}
//Console.WriteLine("");

//gameContext.EventManager.Publish(new PartyMemberInstanceSelectedEvent(gameContext.PartymemberManager.ActivePartymemberInstances[1]));
////gameContext.EventManager.Publish(new HeroInstanceSelectedEvent(gameContext.HeroManager.BaseHeroInstance));
//gameContext.EventManager.Publish(new MonsterInstanceSelectedEvent(gameContext.DungeonManager.MonsterInstances[0]));

//Console.WriteLine("After Fight:");
//foreach (var monster in gameContext.DungeonManager.MonsterInstances)
//{
//    Console.WriteLine($"Monster Type: {monster.Data.MonsterType}, CurrentLife: {monster.CurrentHealth}");
//}
//Console.WriteLine("");


//foreach (var partymember in gameContext.PartymemberManager.DeadPartymemberInstances)
//{
//    Console.WriteLine($"Partymember dead: {partymember.Data.Class}");
//}
//Console.WriteLine("");

//foreach (var partymember in gameContext.PartymemberManager.ActivePartymemberInstances)
//{
//    Console.WriteLine($"Partymember alive: {partymember.Data.Class}");
//}
//Console.WriteLine("");
//Console.WriteLine("-------------------------------------------------------------------------------------------------------");
//#endregion


//#region ItemUsage
//Console.WriteLine("Using Item:");
//itemFactory.CreateItemInstance(ItemType.Potion);

//gameContext.EventManager.Publish(new PartyMemberInstanceSelectedEvent(gameContext.PartymemberManager.ActivePartymemberInstances[0]));
//gameContext.EventManager.Publish(new ItemInstanceSelectedEvent(gameContext.InventoryManager.ItemInstancesInInventory[0]));

//foreach (var partymember in gameContext.PartymemberManager.DeadPartymemberInstances)
//{
//    Console.WriteLine($"Partymember dead: {partymember.Data.Class}");
//}
//Console.WriteLine("");

//foreach (var partymember in gameContext.PartymemberManager.ActivePartymemberInstances)
//{
//    Console.WriteLine($"Partymember alive: {partymember.Data.Class}");
//}
//Console.WriteLine("");
//Console.WriteLine("-------------------------------------------------------------------------------------------------------");
//#endregion


#region TreasureChestLooting
Console.WriteLine("Looting Treasure Chest:");
dungeonEntityFactory.CreateLootInstance(LootType.TreasureChest);
gameContext.EventManager.Publish(new PartyMemberInstanceSelectedEvent(gameContext.PartymemberManager.ActivePartymemberInstances[0]));
//gameContext.EventManager.Publish(new HeroInstanceSelectedEvent(gameContext.HeroManager.BaseHeroInstance));
gameContext.EventManager.Publish(new LootInstanceSelectedEvent(gameContext.DungeonManager.LootInstances[0]));
Console.WriteLine("");

foreach (var item in gameContext.InventoryManager.ItemInstancesInInventory)
{
    Console.WriteLine($"Item in Inventory: {item.ItemData.ItemType}");
}
Console.WriteLine("-------------------------------------------------------------------------------------------------------");
#endregion

