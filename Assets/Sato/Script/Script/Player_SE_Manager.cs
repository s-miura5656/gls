using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SE_Manager : MonoBehaviour
{

    //[SerializeField] private AudioClip charge_sound;
    //[SerializeField] private AudioClip shot_sound;
    [SerializeField] private AudioClip reflect_sound;

    private AudioSource audio_se = null;

    // Start is called before the first frame update
    void Start()
    {
        audio_se = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// ビルにぶつかった時に出す音
    /// </summary>
    public void PlayHitSound() 
    {
        audio_se.PlayOneShot(reflect_sound);
    }
}
