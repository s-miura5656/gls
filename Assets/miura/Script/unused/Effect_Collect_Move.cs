using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Collect_Move : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        Destroy(gameObject, 2f);
    }
}
