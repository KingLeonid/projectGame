using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class ProfileUIScript : MonoBehaviour
{
   
    public ToggleGroup profilesGroup;
    public GameObject addProfilePanel;
    public Toggle profilePrefab;
    public TMP_InputField  inputField;
    public GameObject profilePanel;
    public GameObject backButton;
    public GameObject createButton;

    // Start is called before the first frame update
    void Start()
    {
        if (Data.instance.profiles.Count != 0)
        {
            for (int i = 0; i < Data.instance.profiles.Count; i++)
            {
                if (i==0)
                {
                    profilePrefab.isOn = true;
                }
                    profilePrefab.GetComponentInChildren<Text>().text = Data.instance.profiles[i].namePlayer;
                    Instantiate(profilePrefab, gameObject.transform).group = profilesGroup;
            }
            
        }
        else
        {
            profilePanel.SetActive(false);
            addProfilePanel.SetActive(true);
            backButton.SetActive(false);
            createButton.transform.localPosition = new Vector3(0, -50f, 0);
        }
       

        
  
    }

    public void PointerEnterButton(TextMeshProUGUI button)
    {
        button.color = new Color(0.3584906f,0f,0f);
    }

    public void PointerExitButton(TextMeshProUGUI button)
    {
        button.color = Color.black;
    }

    public void OnClickBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickBackCreatePanelButton()
    {
        addProfilePanel.SetActive(false);
        inputField.text = "";
    }

    public void OnClickCreateButton()
    {
        if (inputField.text.Length == 0  )
        {
            inputField.image.color = Color.white;
            inputField.text = "";
            inputField.placeholder.GetComponent<TextMeshProUGUI>().text = "Введите имя";
        }
        else
         if (inputField.text.Length > 10)
        {
            inputField.image.color = Color.white;
            inputField.text = "";
            inputField.placeholder.GetComponent<TextMeshProUGUI>().text = "Не более 10 символов";
        }
        else
        {
            inputField.placeholder.GetComponent<TextMeshProUGUI>().text = "";
            profilePrefab.GetComponentInChildren<Text>().text = inputField.text;
            profilePrefab.isOn = true;
            Instantiate(profilePrefab, gameObject.transform).group = profilesGroup;
            Data.instance.profiles.Add(new Profile() { namePlayer = inputField.text, countCompletedChapters = 0});
            inputField.text = "";
            PlayerPrefs.SetString("Profiles", JsonHelper.ToJson<List<Profile>>(Data.instance.profiles, true));
            PlayerPrefs.Save();
            if (Data.instance.profiles.Count == 1)
            {   
                SceneManager.LoadScene("MainMenu");
            }
            else
                addProfilePanel.SetActive(false);
           
        }
    }

    public void OnClickAddButton()
    {
        addProfilePanel.SetActive(true);
    }

    public void OnClickDeleteButton()
    {
        IEnumerable<Toggle> profiles = profilesGroup.ActiveToggles();
        foreach (Toggle profile in profiles)
        {
            if (profile.isOn)
            {
                
                Data.instance.profiles.Remove(Data.instance.profiles.Find(item => item.namePlayer == profile.GetComponentInChildren<Text>().text));
                Destroy(profile.gameObject);
                PlayerPrefs.SetString("Profiles", JsonHelper.ToJson<List<Profile>>(Data.instance.profiles, true));
                PlayerPrefs.Save();

                return;
            }
        }
    }
  
    public void OnClickEnterButton()
    {
        IEnumerable<Toggle> profiles = profilesGroup.ActiveToggles();
        foreach (Toggle profile in profiles)
        {
            if (profile.isOn)
            {
                for (int i=0; i<Data.instance.profiles.Count; i++)
                {
                        if (Data.instance.profiles[i].namePlayer == profile.GetComponentInChildren<Text>().text)
                        {
                            Data.instance.LoadProfile = i;
                        PlayerPrefs.SetInt("LoadProfile", Data.instance.LoadProfile);
                        PlayerPrefs.Save();
                    }
                }
                SceneManager.LoadScene("MainMenu");
                return;
            }
        }
         
    }
}
