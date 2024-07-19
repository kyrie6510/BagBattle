using System;
using System.Collections.Generic;
using Script;

namespace Game
{
    public class EventManager : Singleton<EventManager>
    {
        public delegate void EventDelegate<T>(T e) where T : BaseEvent;

        private delegate void EventDelegate(BaseEvent e) ;
        
        private Dictionary<Type, EventDelegate> _delegates = new Dictionary<Type, EventDelegate>();
        private Dictionary<int, EventDelegate> _delegateLookup = new Dictionary<int, EventDelegate>();


        public void AddListener<T>(EventDelegate<T> del) where T : BaseEvent
        {
            var key = del.GetHashCode();
            if (_delegateLookup.ContainsKey(key))
            {
                return;
            }
            
            //从泛型委托转换成普通委托
            EventDelegate internalDelegate = e => del((T) e);
            _delegateLookup[key] = internalDelegate;
            
            EventDelegate tempDel;
            if (_delegates.TryGetValue(typeof(T), out tempDel))
            {
                _delegates[typeof(T)] = tempDel += internalDelegate;
            }
            else
            {
                _delegates[typeof(T)] = internalDelegate;
            }
        }

        public void RemoveListener<T>(EventDelegate<T> del) where T : BaseEvent
        {
            var key = del.GetHashCode();
            if (_delegateLookup.ContainsKey(key))
            {
                var internalDelegate = _delegateLookup[key];
                
                EventDelegate collectionDel;
                if (_delegates.TryGetValue(typeof(T), out collectionDel))
                {
                    collectionDel -= internalDelegate;
                    if (collectionDel == null)
                    {
                        _delegates.Remove(typeof(T));
                    }
                    else
                    {
                        _delegates[typeof(T)] = collectionDel;
                    }

                }    
            }
            
            _delegateLookup.Remove(key);
        }

        public void TriggerEvent(BaseEvent e)
        {
            var type =e.GetType();
            if (_delegates.ContainsKey(type))
            {
                _delegates[type].Invoke(e);
            }
        }
        


    }
}