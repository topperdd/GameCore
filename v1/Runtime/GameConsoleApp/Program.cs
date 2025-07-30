using GameCore.Partymember;
using GameRuntime.Contexts;
using GameRuntime.Events;
using GameSystems.Factories;
using GameSystems.Managers;

var gameContext = new GameContext();
var targetSelectionManager = new TargetSelectionManager(gameContext);

var partymemberFactory = new PartymemberFactory(gameContext);
partymemberFactory.CreatePartymemberInstance(PartymemberClass.Warrior);
partymemberFactory.CreatePartymemberInstance(PartymemberClass.Mage);


var dungeonEntityFactory = new DungeonEntityFactory(gameContext);
dungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);

foreach (var partymember in gameContext.PartymemberManager.PartymemberInstances)
{
    Console.WriteLine($"Partymember Class: {partymember.Data.Class.ToString()}");
}
Console.WriteLine("");

Console.WriteLine($"Monster Type: {gameContext.DungeonManager.MonsterInstances[0].Data.MonsterType}, CurrentLife: {gameContext.DungeonManager.MonsterInstances[0].CurrentHealth}");
Console.WriteLine("");

gameContext.EventManager.Publish(new PartyMemberInstanceSelectedEvent(gameContext.PartymemberManager.PartymemberInstances[0]));
gameContext.EventManager.Publish(new MonsterInstanceSelectedEvent(gameContext.DungeonManager.MonsterInstances[0]));

gameContext.DungeonManager.MonsterInstances[0].TakeDamage(10);
Console.WriteLine($"Monster Type: {gameContext.DungeonManager.MonsterInstances[0].Data.MonsterType}, CurrentLife: {gameContext.DungeonManager.MonsterInstances[0].CurrentHealth}");
Console.WriteLine("");