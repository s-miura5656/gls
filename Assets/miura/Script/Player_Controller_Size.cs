using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_Size : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 max_size = new Vector3(10f, 10f, 10f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("up"))
        //{
        //    transform.localScale += new Vector3(1f, 1f, 1f);
        //    transform.position += new Vector3(0f, 0.5f, 0f);
        //    rb.mass += 5;
        //}

        //if (Input.GetKeyDown("down"))
        //{
        //    transform.localScale -= new Vector3(1f, 1f, 1f);
        //    transform.position -= new Vector3(0f, 0.5f, 0f);
        //    rb.mass -= 5;
        //}
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "block")
        {
            if (transform.localScale != max_size)
            {
                transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                transform.position += new Vector3(0f, 0.05f, 0f);
                rb.mass += 5;
            }
        }
    }
}
