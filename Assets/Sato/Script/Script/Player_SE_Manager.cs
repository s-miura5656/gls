using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SE_Manager : MonoBehaviour
{

    //[SerializeField] private AudioClip charge_sound;
    [SerializeField] private AudioClip destroy_sound;
    [SerializeField] private AudioClip impact_sound;

    private AudioSource[] audio_se = null;

    // Start is called before the first frame update
    void Start()
    {
        audio_se = gameObject.GetComponents<AudioSource>();
    }

    /// <summary>
    /// ビルにぶつかった時に出す音
    /// </summary>
    public void PlayHitSound() 
    {
        audio_se[0].PlayOneShot(impact_sound);
    }

    /// <summary>
    /// ビルを壊したときの音
    /// </summary>
    public void PlayBillDestroySound()
    {
        audio_se[1].PlayOneShot(destroy_sound);
    }
}
