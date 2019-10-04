using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SE : MonoBehaviour
{

    [SerializeField] private AudioClip charge_sound;
    [SerializeField] private AudioClip shot_sound;

    private AudioSource[] audio_se;

    // Start is called before the first frame update
    void Start()
    {
        audio_se = gameObject.GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audio_se[0].PlayOneShot(charge_sound);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            audio_se[1].PlayOneShot(shot_sound);
        }
    }
}
