using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterUIScript : MonoBehaviour
{
    // hint button
    private bool activeHelpButton = true;
    private Vector3 posEffect;
    public float timeLoading;
    public SpriteRenderer[] searchingObjects;
    public Image loadingButton;

    //rooms
    public Image Room1;
    public Image Room2;
    //menu 
    public GameObject menu;

    void Start()
    {

    }

    private void Update()
    {
        if (!activeHelpButton && !PauseScript.instance.boolPause)
        {
            loadingButton.fillAmount -= (Time.deltaTime / timeLoading);
            if (loadingButton.fillAmount <= 0)
            {
                activeHelpButton = true;
                SpecialEffectsHelper.Instance.HintEffect(loadingButton.gameObject.transform.position);
            }
        }
    }

    public void ClickHintButton()
    {
        if (activeHelpButton)
        {
            
            loadingButton.fillAmount = 1;
            if (searchingObjects[0] == null)
            {
                Array.Clear(searchingObjects, 0, 1);
                searchingObjects = searchingObjects.Where(val => val != null).ToArray();
            }
            if (!searchingObjects[0].isVisible)
            {
                if (Room1.IsActive())
                    SpecialEffectsHelper.Instance.HintEffect(Room1.transform.position);
                else
                    SpecialEffectsHelper.Instance.HintEffect(Room2.transform.position);

            }
            else
            {
                posEffect = new Vector3(searchingObjects[0].transform.position.x, searchingObjects[0].transform.position.y, -2f);
                SpecialEffectsHelper.Instance.HintEffect(posEffect);
            }
            activeHelpButton = false;
        }
    }

    public void ClickMenuButton()
    {
        menu.SetActive(true);
        PauseScript.instance.boolPause = true;
    }

    public void ClickAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ClickContinueButton()
    {
        menu.SetActive(false);
        PauseScript.instance.boolPause = false;
    }

    public void ClickExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ClickNextButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
