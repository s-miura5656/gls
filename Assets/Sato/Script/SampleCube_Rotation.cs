using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SampleCube_Rotation : MonoBehaviour
{
    


    void Start()
    {
        
    }

  
    void Update()
    {
     
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime, Space.Self);

    }
}
