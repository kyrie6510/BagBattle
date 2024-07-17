using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Singleton<T> where T : new ()
{
    private static T _ins;

    public static T Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new T();
            }

            return _ins;
        }


    }
}

public class SingletonMon<T> : MonoBehaviour where T : SingletonMon<T> {
    protected static T _instance;

    public static T Ins {
        get {
            return _instance;
        }
    }

    protected virtual void Awake() {
        _instance = this as T;
    }

    protected virtual void OnDestroy() {
        if (_instance == this) {
            _instance = null;
        }
    }
}


public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    public static T Ins = null;

    protected virtual void Awake()
    {
        Ins = this as T;
    }
}



public static class  GameStated
{
    public static readonly int ClickFromNode = 0;
    public static readonly int ClickToNode = 1;
    public static readonly int ClickBlock = 2;
    public static readonly int GameStart = 3;
}




