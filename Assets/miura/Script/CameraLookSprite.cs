using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookSprite : MonoBehaviour
{

    private Camera _camera = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if (_camera == null)
        {
            return;
        }

        transform.LookAt(_camera.transform);
    }

    public void SetCamera(Camera taget)
    {
        _camera = taget;
    }

}
