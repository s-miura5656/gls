using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Generator : MonoBehaviour
{
    // プレイヤー
    private GameObject player;
    // プレイヤーのコピー
    private GameObject player_copy;
    // Start is called before the first frame update
    void Start()
    {
        player = (GameObject)Resources.Load("Player");
        player_copy = Instantiate(player);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
