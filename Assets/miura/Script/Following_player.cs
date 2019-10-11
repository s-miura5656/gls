using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following_player : MonoBehaviour
{
    // プレイヤーの過去の座標
    private Vector3[] old_player_pos = new Vector3[50];
    [SerializeField] private GameObject[] player_bullets;

    private void Start()
    {
        for (int i = 0; i < old_player_pos.Length; i++)
        {
            old_player_pos[i] = transform.position;
        }
    }

    private void Update()
    {
        for (int i = old_player_pos.Length - 2; i >= 0; i--)
        {
            old_player_pos[i + 1] = old_player_pos[i];
        }

        old_player_pos[0] = transform.position;

        for (int i = 0; i < 5; i++)
        {
            if (player_bullets[i].activeSelf == true)
            {
                player_bullets[i].transform.position = old_player_pos[(i + 1) * 4];
            }
        }
        
    }
}
