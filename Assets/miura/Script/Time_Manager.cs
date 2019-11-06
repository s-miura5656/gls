using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Manager : MonoBehaviour
{
    private float time_count = 0f;
    private float time_max = 61f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_count += Time.deltaTime;

        if (time_count >= time_max)
        {

        }
    }
}
