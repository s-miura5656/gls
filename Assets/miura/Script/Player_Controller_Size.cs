using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_Size : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            transform.localScale += new Vector3(1f, 1f, 1f);
            rb.mass += 5;
        }

        if (Input.GetKeyDown("down"))
        {
            transform.localScale -= new Vector3(1f, 1f, 1f);
            rb.mass -= 5;
        }
    }
}
