using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour
    where T:MonoBehaviour
{
    static Singleton<T> _instancia;
    static readonly object _syncLock = new object();
    protected virtual void Awake()
    {
        bool destroyInstancia = true;
        if (_instancia==null)
        {
            lock(_syncLock)
            {
                if (_instancia==null)
                {
                    _instancia = this;
                    DontDestroyOnLoad(gameObject);
                    destroyInstancia = false;
                }
            }

        }

        if (destroyInstancia == true)
        {
            Destroy(gameObject);
            return;
        }

    }


    public static Singleton<T> GetInstancia()
    {
        return _instancia;       
    }
}
