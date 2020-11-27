using UnityEngine;

public class Data : MonoBehaviour
{

    public static Data instance;

    public int countCompletedChapters;
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