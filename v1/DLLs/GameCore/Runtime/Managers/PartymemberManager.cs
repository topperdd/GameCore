using GameCore.Contexts;
using GameCore.Runtime.Events;
using GameCore.Runtime.Events.Combat;
using GameCore.Runtime.Events.Creation;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Managers
{
    public class PartymemberManager
    {
        private GameContext _gameContext { get; set; }

        public List<PartymemberInstance> ActivePartymemberInstances { get; private set; } = new List<PartymemberInstance>();
        public List<PartymemberInstance> DeadPartymemberInstances { get; private set; } = new List<PartymemberInstance>();

        public PartymemberManager(GameContext gameContext)
        {
            _gameContext = gameContext;

            _gameContext.EventManager.Subscribe<PartymemberCreatedEvent>(OnPartymemberCreated);
            _gameContext.EventManager.Subscribe<PartymemberDiedEvent>(OnPartymemberDied);
            _gameContext.EventManager.Subscribe<PartymemberRevivedEvent>(OnPartymemberRevived);

            _gameContext.EventManager.Subscribe<DragonKilledEvent>(OnDragonKilled);
        }

        private void OnDragonKilled(DragonKilledEvent e)
        {
            foreach (var fighter in e.DragonFighters)
            {
                switch (fighter)
                {
                    case PartymemberInstance partymember:
                        _gameContext.EventManager.Publish(new PartymemberDiedEvent(partymember));
                        break;
                }
            }
        }

        private void OnPartymemberRevived(PartymemberRevivedEvent e)
        {
            DeadPartymemberInstances.Remove(e.Partymember);
            ActivePartymemberInstances.Add(e.Partymember);
        }

        private void OnPartymemberDied(PartymemberDiedEvent e)
        {
            DeadPartymemberInstances.Add(e.PartymemberInstance);
            ActivePartymemberInstances.Remove(e.PartymemberInstance);
        }


        private void OnPartymemberCreated(PartymemberCreatedEvent e)
        {
            ActivePartymemberInstances.Add(e.PartymemberInstance);
        }
    }
}
