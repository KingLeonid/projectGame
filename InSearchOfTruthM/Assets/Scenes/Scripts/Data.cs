using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

[Serializable]
public class Profile
{
    public string namePlayer;
    public int countCompletedChapters;
}

[Serializable]
public class Data : MonoBehaviour
{

   
    public static Data instance;
    [SerializeField]
    public List<Profile> profiles = new List<Profile>(10);
    public int LoadProfile;
    //settings
    public float valSound;
    public float valMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}