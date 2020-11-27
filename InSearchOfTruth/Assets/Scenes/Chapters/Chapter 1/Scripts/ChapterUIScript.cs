using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterUIScript : MonoBehaviour
{
    // hint button
    public Button helpButton;
    public float timeLoading;
    public GameObject searchingObjects;
    public Image loadingButton;

    //inventary
    public Scrollbar scrollbar;
    public float valueScrollbar;

    //menu 
    public GameObject menu;
    void Start()
    {

    }

    private void Update()
    {
       if (!helpButton.enabled)
        {
            loadingButton.fillAmount -= (Time.deltaTime / timeLoading);
            if (loadingButton.fillAmount <=0)
            {
                helpButton.enabled = true;
                SpecialEffectsHelper.Instance.HintEffect(helpButton.gameObject.transform.position);
            }
        }
    }

    public void ClickHintButton()
    {
        loadingButton.fillAmount = 1;
        SpecialEffectsHelper.Instance.HintEffect(searchingObjects.GetComponentsInChildren<SpriteRenderer>()[1].transform.position);
        helpButton.enabled = false;   
    }

    public void ClickMenuButton()
    {
        menu.SetActive(true);
    }

    public void ClickContinueButton()
    {
        menu.SetActive(false);
    }

    public void ClickExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ClickNextButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ClickLeftButton()
    {
        scrollbar.value -= valueScrollbar;
    }

    public void ClickRightButton() 
    {
        scrollbar.value += valueScrollbar;
    }
}
