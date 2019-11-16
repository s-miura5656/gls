using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SE : MonoBehaviour
{

    //[SerializeField] private AudioClip charge_sound;
    //[SerializeField] private AudioClip shot_sound;
    [SerializeField] private AudioClip reflect_sound;

    private AudioSource[] audio_ses = new AudioSource[3];

    // Start is called before the first frame update
    void Start()
    {
        audio_ses = gameObject.GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            audio_ses[0].PlayOneShot(reflect_sound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            audio_ses[0].PlayOneShot(reflect_sound);
        }
    }
}
