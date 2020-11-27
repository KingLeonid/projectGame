using UnityEngine;
using System.Collections;
using UnityEngine.UI;
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
            Data.instance.countCompletedChapters += 1;
            
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings-1)
            {
                nextButton.SetActive(false);
                menuButton.transform.localPosition = new Vector3 (0, -46.7f, 0);
            }
        }
    }
}
