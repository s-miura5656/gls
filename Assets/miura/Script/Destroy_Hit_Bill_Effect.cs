using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Hit_Bill_Effect : MonoBehaviour
{
    private GameObject level_zero_obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1.5f);
    }
}
