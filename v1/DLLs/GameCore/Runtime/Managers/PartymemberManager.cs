using GameCore.Contexts;
using GameCore.Runtime.Events.Combat;
using GameCore.Runtime.Events.Creation;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Managers
{
    public class PartymemberManager
    {
        public List<PartymemberInstance> ActivePartymemberInstances { get; private set; } = new List<PartymemberInstance>();
        public List<PartymemberInstance> DeadPartymemberInstances { get; private set; } = new List<PartymemberInstance>();

        public PartymemberManager(GameContext gameContext)
        {
            gameContext.EventManager.Subscribe<PartymemberCreatedEvent>(OnPartymemberCreated);
            gameContext.EventManager.Subscribe<PartymemberDiedEvent>(OnPartymemberDied);
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
