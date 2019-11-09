using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Stop_Manager : MonoBehaviour
{
    private float time_count = 0f;
    private bool time_switch = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        time_count += 0.1f;

        Debug.Log(time_count);

        if (time_count >= 0.8f && time_switch == false)
        {
            Time.timeScale = 1f;
            time_switch = true;
        }
    }

    public void TimeStop() 
    {
        time_count = 0f;
        Time.timeScale = 0f;
        time_switch = false;
    }
}
