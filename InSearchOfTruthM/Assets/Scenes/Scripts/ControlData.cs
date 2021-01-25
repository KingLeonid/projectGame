using UnityEngine;
using System;
using System.Collections.Generic;

public static class JsonHelper
{

    public static List<Profile> FromJson<List>(string json)
    {
       Profiles wrapper = JsonUtility.FromJson<Profiles>(json);
        return wrapper.profiles;
    }

    public static string ToJson<List>(List<Profile> array)
    {
        Profiles wrapper = new Profiles();
        wrapper.profiles = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<List>(List<Profile> array, bool prettyPrint)
    {
        Profiles wrapper = new Profiles();
        wrapper.profiles = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Profiles
    {
        public List<Profile> profiles = Data.instance.profiles;
    }
}

public class ControlData : MonoBehaviour
    {
    private void Awake()
    {

        if (PlayerPrefs.HasKey("Profiles"))
        {
            Data.instance.profiles = JsonHelper.FromJson<List<Profile>>(PlayerPrefs.GetString("Profiles"));
            Data.instance.LoadProfile = PlayerPrefs.GetInt("LoadProfile");
            Data.instance.valMusic = PlayerPrefs.GetFloat("valMusic");
            Data.instance.valSound = PlayerPrefs.GetFloat("valSound");
        }
    }
    private void OnApplicationQuit()
    {
        string profilesPlayers = JsonHelper.ToJson<List<Profile>>(Data.instance.profiles, true);
        PlayerPrefs.SetString("Profiles", profilesPlayers);
        PlayerPrefs.SetInt("LoadProfile", Data.instance.LoadProfile);
        PlayerPrefs.SetFloat("valMusic", Data.instance.valMusic);
        PlayerPrefs.SetFloat("valSound", Data.instance.valSound);
        PlayerPrefs.Save();
    }

}
