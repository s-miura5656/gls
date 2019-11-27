using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bill_Color_Set : MonoBehaviour
{
    private GameObject game_manager;

    private Player_Level_Manager player_level_script;

    private Bill_Destroy bill_level_script;

    private Renderer renderer = null;

    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.Find("GameManager");
        renderer = gameObject.GetComponent<Renderer>();
        renderer.material.color = Color.black;

        player_level_script = game_manager.GetComponent<Player_Level_Manager>();

        bill_level_script = gameObject.GetComponent<Bill_Destroy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player_level_script.GetLevel() >= bill_level_script.GetBillLevel())
        {
            renderer.material.color = Color.white;
        }
    }
}
