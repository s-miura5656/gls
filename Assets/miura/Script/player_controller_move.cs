using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller_move : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 startPos;
    public float speed;
    public Vector3 startDirection;
    [SerializeField]
    //private ArrowsController arrowsscript;
    public Vector3 velo;
    public Vector3 vec;
    public bool start_posion;
    private bool gameOut = false;
    private float powor = 200;
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // マウスの動きと反対方向に発射される
        if (Input.GetMouseButtonDown(0))
        {
            this.rb.velocity = Vector3.Normalize(this.rb.velocity) * 3.0f;
            this.startPos = Input.mousePosition;
            startDirection *= 0;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            this.rb.velocity = Vector3.zero;
            Vector3 endPos = Input.mousePosition;
            startDirection = -1 * (endPos - startPos).normalized;
            rb.AddForce(new Vector3(startDirection.x * powor, 0f, startDirection.y * powor), ForceMode.Impulse);

            //rb.AddForce(arrowsscript.transform.right * arrowsscript.distance * speed * 0.01f, ForceMode.VelocityChange);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            gameOut = true;
        }

    }
}
