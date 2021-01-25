using UnityEngine;
using UnityEngine.UI;

public class OnTime : MonoBehaviour
{
    public float timeGame;
    public GameObject gameOver;
    private Image timer;



    void Start()
    {
        timer = gameObject.GetComponent<Image>();
        gameObject.GetComponent<Image>().fillAmount = 1;
        gameOver.SetActive(false);

    }

    void Update()
    {
        if (!PauseScript.instance.boolPause)
        {
            timer.color = new Color(1, timer.fillAmount, timer.fillAmount);
            timer.fillAmount -= (Time.deltaTime / timeGame);

            if (timer.fillAmount <= 0)
            {
                gameOver.SetActive(true);
            }
        }
    }


}
