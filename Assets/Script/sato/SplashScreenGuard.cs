using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SplashScreenGuard : MonoBehaviour
{
    [SerializeField]
    private GraphicRaycaster graphicRaycaster;
    [SerializeField]
    private float time;

    private void Start()
    {
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                graphicRaycaster.enabled = true;
            }
        }
    }
}
