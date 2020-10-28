using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChapterListSceneUIScript : MonoBehaviour
{
    public ToggleGroup chaptersGroup;

    public void BackButtonOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
 
    public void PlayButtonOnClick()
    {
        IEnumerable<Toggle> chapters = chaptersGroup.ActiveToggles();
        foreach (Toggle chapter in chapters)
        {
            if (chapter.isOn)
            {
                // Load selected chapter
                SceneManager.LoadScene(chapter.GetComponent<LoadingTheSelectChapter>().scene.handle);
                Debug.Log("Load "+ chapter.name);
                return;
            }
        }
    }
}
