using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Zero_Crash : MonoBehaviour
{
    private float destroy_time = 1.5f;
    private GameObject game_manager;
    private Destruction_Rate_Manager destruction_rate_script;
    private Collider col;

    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.Find("GameManager");
        destruction_rate_script = game_manager.GetComponent<Destruction_Rate_Manager>();
        col = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Load")
        {
            // 破壊率計算用の関数
            destruction_rate_script.DownNowRate();
            col.enabled = false;
            Destroy(gameObject, destroy_time);
        }
    }
}
