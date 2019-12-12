using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookSprite : MonoBehaviour
{
    private float obj_pos_y = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(0f, obj_pos_y, 0f);

        obj_pos_y += 0.1f;

        if (transform.position.y >= 100)
        {
            Destroy(gameObject);
        }

    }
}
