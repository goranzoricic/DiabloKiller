using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DiabloKiller {


    public abstract class EventData {
    }

    public class EventManager : Updateable {
        public static EventManager Instance {
            get { return Singleton<EventManager>.Instance; }
            private set { }
        }

        private class Event {
            private List<Action<EventData>> listeners = new List<Action<EventData>>();
            public string Name;

            public Event(string eventName, Action<EventData> listener) {
                Name = eventName;
                AddListener(listener);
            }

            public int NumListeners {
                get { return listeners.Count; }
                private set { }
            }
            public void AddListener(Action<EventData> listener) {
                if (listeners.Contains(listener)) {
                    Debug.LogErrorFormat("Registering an already registered event listener for event: {0}", Name);
                    return;
                }
                listeners.Add(listener);
            }
            public void RemoveListener(Action<EventData> listener) {
                if (!listeners.Contains(listener)) {
                    Debug.LogErrorFormat("Removing an event listener that isn't registered, for event: {0}", Name);
                    return;
                }
                listeners.Remove(listener);
            }

            public void Trigger(EventData eventData) {
                foreach (Action<EventData> listener in listeners) {
                    listener(eventData);
                }
            }
        }

        private Dictionary<string, Event> events = new Dictionary<string, Event>();

        // Update is called once per frame
        public override void Update() {
            //Debug.Log("[EventManager.Update] update executed");

        }

        public void AddEventListener(string eventName, Action<EventData> callback) {
            Event registeredEvent;
            if (events.TryGetValue(eventName, out registeredEvent)) {
                registeredEvent.AddListener(callback);
            } else {
                registeredEvent = new Event(eventName, callback);
                events.Add(eventName, registeredEvent);
            }
        }

        public void RemoveEventListener(string eventName, Action<EventData> callback) {
            Event registeredEvent;
            if (events.TryGetValue(eventName, out registeredEvent)) {
                registeredEvent.RemoveListener(callback);
                if (registeredEvent.NumListeners == 0) {
                    events.Remove(eventName);
                }
            } else {
                registeredEvent = new Event(eventName, callback);
                events.Add(eventName, registeredEvent);
            }
        }

        public void TriggerEvent(string eventName, EventData eventdata) {
            Event registeredEvent;
            if (events.TryGetValue(eventName, out registeredEvent)) {
                registeredEvent.Trigger(eventdata);
            }
        }
    }
}
