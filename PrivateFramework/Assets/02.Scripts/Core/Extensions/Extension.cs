using UnityEngine;

namespace _02.Scripts.Core.Extensions
{
    public static class Extension
    {
        public static T GetOrAddComponent<T>(GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            if (component == null) component = gameObject.AddComponent<T>();
            return component;
        }
    }
}