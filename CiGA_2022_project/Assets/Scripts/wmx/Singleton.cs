using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: Singleton<T>, new()
{
    protected static T _instance;
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
                //_instance = this;
            }
            return _instance;
        }
    }
}

public class SingletonNoMono<T> where T : SingletonNoMono<T>, new()
{
    protected static T _instance;
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }
}
