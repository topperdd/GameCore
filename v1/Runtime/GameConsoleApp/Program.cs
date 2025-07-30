using GameCore.Partymember;
using GameRuntime.Contexts;
using GameRuntime.Events;
using GameSystems.Factories;
using GameSystems.Managers;

var gameContext = new GameContext();
var targetSelectionManager = new TargetSelectionManager(gameContext);

var partymemberFactory = new PartymemberFactory(gameContext);
var dungeonEntityFactory = new DungeonEntityFactory();

partymemberFactory.CreatePartymemberInstance(PartymemberClass.Warrior);
partymemberFactory.CreatePartymemberInstance(PartymemberClass.Mage);

foreach (var partymember in gameContext.PartymemberManager.PartymemberInstances)
{
    Console.WriteLine($"Partymember Class: {partymember.Data.Class.ToString()}");
}
Console.WriteLine("");

var goblinInstance = dungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
Console.WriteLine($"Monster Type: {goblinInstance.Data.MonsterType.ToString()}, MaxLife: {goblinInstance.Data.MaxHealth}");
Console.WriteLine("");

gameContext.EventManager.Publish(new PartyMemberInstanceSelectedEvent(gameContext.PartymemberManager.PartymemberInstances[0]));
gameContext.EventManager.Publish(new MonsterInstanceSelectedEvent(goblinInstance));

goblinInstance.TakeDamage(10);
Console.WriteLine($"Monster Type: {goblinInstance.Data.MonsterType.ToString()}, CurrentLife: {goblinInstance.CurrentHealth}");
Console.WriteLine("");