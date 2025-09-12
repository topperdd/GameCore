using GameCore.Partymember;
using GameRuntime.Contexts;
using GameRuntime.Events;
using GameSystems.Factories;
using GameSystems.Managers;

var gameContext = new GameContext();
var targetSelectionManager = new TargetSelectionManager(gameContext);
var combatResolveManager = new CombatResolveManager(gameContext);

var partymemberFactory = new PartymemberFactory(gameContext);
partymemberFactory.CreatePartymemberInstance(PartymemberClass.Warrior);
partymemberFactory.CreatePartymemberInstance(PartymemberClass.Mage);


var dungeonEntityFactory = new DungeonEntityFactory(gameContext);
dungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
dungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
dungeonEntityFactory.CreateMonsterInstance(MonsterType.Ooze);
dungeonEntityFactory.CreateMonsterInstance(MonsterType.Ooze);

foreach (var partymember in gameContext.PartymemberManager.PartymemberInstances)
{
    Console.WriteLine($"Partymember Class: {partymember.Data.Class.ToString()}");
}
Console.WriteLine("");

Console.WriteLine("Before Fight:");
foreach (var monster in gameContext.DungeonManager.MonsterInstances)
{
    Console.WriteLine($"Monster Type: {monster.Data.MonsterType}, CurrentLife: {monster.CurrentHealth}");
}
Console.WriteLine("");

gameContext.EventManager.Publish(new PartyMemberInstanceSelectedEvent(gameContext.PartymemberManager.PartymemberInstances[1]));
gameContext.EventManager.Publish(new MonsterInstanceSelectedEvent(gameContext.DungeonManager.MonsterInstances[1]));

Console.WriteLine("After Fight:");
foreach (var monster in gameContext.DungeonManager.MonsterInstances)
{
    Console.WriteLine($"Monster Type: {monster.Data.MonsterType}, CurrentLife: {monster.CurrentHealth}");
}
Console.WriteLine("");
