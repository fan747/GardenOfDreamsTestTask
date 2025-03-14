using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Scripts.Core.ServiceLocator
{
    public class ServiceLocator
    {
        private readonly Dictionary<string, object> _services = new Dictionary<string, object>();

        public static ServiceLocator Current { get; private set; }

        public static void Initialize()
        {
            if (Current != null) return;

            Current = new();
        }

        public void Register<T>(T service)
        {
            if (service == null)
            {
                Debug.LogError("An attempt to register an service == null");
                return;
            }

            string key = typeof(T).Name;
            if (_services.ContainsKey(key))
            {
                Debug.LogError("An attempt to register an already registered service");
                return;
            }

            _services.Add(key, service);
        }

        public void Unregister<T>(T service)
        {
            string key = typeof(T).Name;
            if (!_services.ContainsKey(key))
            {
                Debug.LogError("An attempt to unregister an already unregistered service");
                return;
            }

            _services.Remove(key);
        }

        public T Get<T>()
        {
            string key = typeof(T).Name;
            if (!_services.ContainsKey(key))
            {
                Debug.LogError($"An attempt to get an unregistered service");
                throw new InvalidOperationException();
            }

            return (T)_services[key];
        }
    }
}