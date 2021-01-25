using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChapterPassed : MonoBehaviour
{
    public GameObject chapterPassed;
    public GameObject nextButton;
    public GameObject menuButton;

    private void OnTransformChildrenChanged()
    {
        if (gameObject.transform.childCount < 1)
        {
            chapterPassed.SetActive(true);
            Data.instance.profiles[Data.instance.LoadProfile].countCompletedChapters += 1;
            PlayerPrefs.SetString("Profiles", JsonHelper.ToJson<List<Profile>>(Data.instance.profiles, true));
            PlayerPrefs.Save();
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                nextButton.SetActive(false);
                menuButton.transform.localPosition = new Vector3(0, -46.7f, 0);
            }
        }
    }
}
