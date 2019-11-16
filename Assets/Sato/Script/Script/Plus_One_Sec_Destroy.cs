using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plus_One_Sec_Destroy : MonoBehaviour
{
    private GameObject player;
    private float obj_pos_y = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player1");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.localScale.y + obj_pos_y, player.transform.position.z);
        obj_pos_y += 0.1f;

        if (transform.position.y >= player.transform.localScale.y + 10f)
        {
            Destroy(gameObject);
        }
    }
}
