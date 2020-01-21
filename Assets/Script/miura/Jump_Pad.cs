using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Pad : MonoBehaviour
{
    [SerializeField] private Rigidbody player_rb = null;
    [SerializeField] private float jump_powor = 0f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_rb.AddForce(new Vector3(0, jump_powor, 0), ForceMode.Impulse);
        }
    }
}
