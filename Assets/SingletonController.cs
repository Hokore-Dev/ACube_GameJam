using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class SingletonController
{
    static Dictionary<System.Type, object> _singletonDic = new Dictionary<System.Type, object>();

    ~SingletonController()
    {
        RemoveAll();
    }

    static T Create<T>()
    {
        string className = typeof(T).Name;
        System.Type type = typeof(T);
        if (!_singletonDic.ContainsKey(type))
        {
            if (type.IsSubclassOf(typeof(UnityEngine.Component)))
            {
                GameObject go = new GameObject();
                go.name = "[SINGLETON]" + type.Name;
                MonoBehaviour.DontDestroyOnLoad(go);
                _singletonDic.Add(type, go.AddComponent(type));
            }
            else
            {
                _singletonDic.Add(type, System.Activator.CreateInstance<T>());
            }
        }

        return (T)_singletonDic[type];
    }

    public static T Get<T>()
    {
        System.Type type = typeof(T);
        return _singletonDic.ContainsKey(type) ? (T)_singletonDic[type] : Create<T>();
    }

    public static void Remove<T>()
    {
        Remove(typeof(T));
    }

    static void Remove(System.Type inType)
    {
        System.Type type = inType;
        if (_singletonDic.ContainsKey(type) && type.IsSubclassOf(typeof(UnityEngine.Component)))
        {
            MonoBehaviour.Destroy(((UnityEngine.Component)_singletonDic[type]).gameObject);
        }

        _singletonDic.Remove(type);
    }

    public static void RemoveAll()
    {
        foreach(var type in _singletonDic.Keys)
        {
            Remove(type);
        }
        _singletonDic.Clear();
    }
}
