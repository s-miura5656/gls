using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Zero_Crash : MonoBehaviour
{
    private float time_count = 0f;
    private float destroy_time = 1.5f;
    private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Load")
        {
            Destroy(gameObject, destroy_time);
        }
    }
}
