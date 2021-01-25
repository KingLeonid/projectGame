using System.Collections;
using UnityEngine;
using System;

[Serializable]
public class Data2 : MonoBehaviour
    {

    public static Data2 inst;
    
    void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else if (inst != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}

