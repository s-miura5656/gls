using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mo : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") / 4;
        float y = Input.GetAxis("Vertical") / 4;

        transform.position += new Vector3(x, y, 0f);
    }
}
