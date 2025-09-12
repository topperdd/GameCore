#nullable disable

using GameRuntime.Contexts;
using GameRuntime.Events;
using GameRuntime.Managers;
using GameSystems.Factories;
using GameSystems.Managers;

var gameContext = new GameContext();
var targetSelectionManager = new TargetSelectionManager(gameContext);
var combatResolveManager = new CombatResolveManager(gameContext);
var partymemberFactory = new PartymemberFactory(gameContext);
var inventoryManager = new InventoryManager(gameContext);
var itemFactory = new ItemFactory(gameContext); 

partymemberFactory.CreatePartymemberInstance(PartymemberClass.Warrior);
partymemberFactory.CreatePartymemberInstance(PartymemberClass.Mage);


var dungeonEntityFactory = new DungeonEntityFactory(gameContext);
dungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
dungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
dungeonEntityFactory.CreateMonsterInstance(MonsterType.Ooze);
dungeonEntityFactory.CreateMonsterInstance(MonsterType.Ooze);

foreach (var partymember in gameContext.PartymemberManager.ActivePartymemberInstances)
{
    Console.WriteLine($"Partymember Class: {partymember.Data.Class.ToString()}");
}
Console.WriteLine("");


#region Fight
//Console.WriteLine("Before Fight:");
//foreach (var monster in gameContext.DungeonManager.MonsterInstances)
//{
//    Console.WriteLine($"Monster Type: {monster.Data.MonsterType}, CurrentLife: {monster.CurrentHealth}");
//}
//Console.WriteLine("");

//gameContext.EventManager.Publish(new PartyMemberInstanceSelectedEvent(gameContext.PartymemberManager.ActivePartymemberInstances[1]));
//gameContext.EventManager.Publish(new MonsterInstanceSelectedEvent(gameContext.DungeonManager.MonsterInstances[1]));

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
#endregion


#region ItemUsage
itemFactory.CreateItemInstance("Potion");

foreach (var item in inventoryManager.ItemInstances)
{
    Console.WriteLine($"Item: {item.ItemData.ItemId}");
    item.Use();
}
#endregion