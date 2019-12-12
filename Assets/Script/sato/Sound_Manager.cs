using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sound_Manager : MonoBehaviour
{
    public GameObject ToggleMute;
    const string MuteKey = "mute";
    Toggle muteToggle;
    void Awake()
    {

        muteToggle = ToggleMute.GetComponent<Toggle>();

        if (PlayerPrefs.HasKey("mute") == false)
        {
            PlayerPrefs.SetInt("mute", 1);
            AudioListener.volume = 0f;
            muteToggle.isOn = true;
        }
        else if (PlayerPrefs.GetInt("mute") == 0)
        {
            AudioListener.volume = 1f;
            muteToggle.isOn = false;
        }
        else
        {
            AudioListener.volume = 0f;
            muteToggle.isOn = true;
        }
    }

    public void Mute(bool mute)
    {
        if (mute)
        {
            PlayerPrefs.SetInt("mute", 1);
            AudioListener.volume = 0f;
        }
        else
        {
            PlayerPrefs.SetInt("mute", 0);
            AudioListener.volume = 1f;
        }
    }
}
