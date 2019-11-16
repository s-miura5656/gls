using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Effect_Destroy : MonoBehaviour
{
    private GameObject level_zero_obj;
    private ParticleSystem hit_effect;
    // Start is called before the first frame update
    void Start()
    {
        hit_effect = gameObject.GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        hit_effect.Simulate(Time.unscaledDeltaTime, false, false);
        Destroy(gameObject, 2f);
    }
}
