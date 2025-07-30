using GameCore.Partymember;
using GameRuntime.Contexts;
using GameRuntime.Events.Creation;

namespace GameRuntime.Managers
{
    public class PartymemberManager
    {
        public List<PartymemberInstance> PartymemberInstances { get; private set; } = new List<PartymemberInstance>();

        public PartymemberManager(GameContext gameContext)
        {
            gameContext.EventManager.Subscribe<PartymemberCreatedEvent>(OnPartymemberCreated);
        }

        private void OnPartymemberCreated(PartymemberCreatedEvent e)
        {
            PartymemberInstances.Add(e.PartymemberInstance);
        }
    }
}
