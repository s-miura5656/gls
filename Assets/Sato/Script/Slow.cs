using UnityEngine;

public class Slow : MonoBehaviour
{
    // Toggles the time scale between 1 and 0.7
    // whenever the user hits the Fire1 button.

    private bool slow_time;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.timeScale >= 1.0f) Time.timeScale = 0.3f;
            slow_time = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1.0f;
            slow_time = false;
        }
    }
}