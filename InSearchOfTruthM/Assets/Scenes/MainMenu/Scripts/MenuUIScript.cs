using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuUIScript : MonoBehaviour
{
    public TextMeshProUGUI nameText;

    private void Start()
    {
        if (Data.instance.profiles.Count != 0)
        {
            if (Data.instance.profiles.Count < Data.instance.LoadProfile+1)
            {
                Data.instance.LoadProfile = 0;
            }
            nameText.text = Data.instance.profiles[Data.instance.LoadProfile].namePlayer;
        }
        else
        {
            SceneManager.LoadScene("ProfileScene");
        }
    }
    public void PlayButtonOnClick()
    {
        SceneManager.LoadScene("ChapterListScene");
    }
    public void ExitButtonOnClick()
    {
        Application.Quit();
    }

    public void PointerEnterName()
    {
        nameText.outlineWidth = 0.21f;
    }

    public void PointerExitName()
    {
        nameText.outlineWidth = 0f;
    }

    public void ProfileButtonOnClick()
    {
        SceneManager.LoadScene("ProfileScene");
    }

}
