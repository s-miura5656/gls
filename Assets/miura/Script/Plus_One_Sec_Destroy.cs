using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plus_One_Sec_Destroy : MonoBehaviour
{
    private GameObject player;
    private float obj_pos_y = 0f;
    private float base_scale_y;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player1");
        base_scale_y = player.transform.localScale.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f) * (player.transform.localScale.y);
        transform.position = new Vector3(player.transform.position.x, player.transform.localScale.y + obj_pos_y, player.transform.position.z);
        obj_pos_y += 0.1f;

        if (transform.position.y >= player.transform.localScale.y + 6f)
        {
            Destroy(gameObject);
        }
    }
}
