using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom_camera : MonoBehaviour
{
    private Camera cam;
    private float scroll = 0.5f;
    private float view;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            view = cam.fieldOfView - scroll;
            cam.fieldOfView = Mathf.Clamp(value: view, min: 40f, max: 60f);
        }
        else
        {
            view = cam.fieldOfView + scroll;
            cam.fieldOfView = Mathf.Clamp(value: view, min: 40f, max: 60f);
        }
        
        
    }
}
