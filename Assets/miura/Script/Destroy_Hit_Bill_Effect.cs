using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Hit_Bill_Effect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2f);
    }
}
