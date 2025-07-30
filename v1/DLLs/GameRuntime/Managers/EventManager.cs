using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRuntime.Managers
{
    public class EventManager
    {
        private Dictionary<Type, Delegate> _events = new Dictionary<Type, Delegate>();

        public void Subscribe<T>(Action<T> listener) where T : class
        {
            if (_events.TryGetValue(typeof(T), out var existingDelegate))
            {
                _events[typeof(T)] = Delegate.Combine(existingDelegate, listener);
            }
            else
            {
                _events[typeof(T)] = listener;
            }
        }

        public void Unsubscribe<T>(Action<T> listener) where T : class
        {
            var eventType = typeof(T);

            if (_events.TryGetValue(eventType, out var existingDelegate))
            {
                var newDelegate = Delegate.Remove(existingDelegate, listener);

                if (newDelegate == null)
                {
                    _events.Remove(eventType);
                }
                else
                {
                    _events[eventType] = newDelegate;
                }
            }
        }

        public void Publish<T>(T eventData) where T : class
        {
            var eventType = typeof(T);

            if (_events.TryGetValue(eventType, out var existingDelegate))
            {
                var action = existingDelegate as Action<T>;
                action?.Invoke(eventData);
            }
        }
    }
}
