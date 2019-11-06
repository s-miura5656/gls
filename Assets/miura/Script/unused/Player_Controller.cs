using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private float move_x;
    private float move_y;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move_x = Input.GetAxis("Horizontal");
        move_y = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(move_x, 0f, move_y) * 10;

        rb.AddForce(force, ForceMode.Force);
    }
}
