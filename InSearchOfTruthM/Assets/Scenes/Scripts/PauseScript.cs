using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static PauseScript instance;
    public bool boolPause;

    private void Awake()
    {
        instance = this;
    }
}
