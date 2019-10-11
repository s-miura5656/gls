using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    [SerializeField] private GameObject[] move_enemy_attack = new GameObject[5];
    private Vector3[] enemy_move = new Vector3[5];
    private float time_count;
    private float pop_time = 3f;
    private bool attack_switch;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < move_enemy_attack.Length; i++)
        {
            move_enemy_attack[i].transform.position = transform.position;
        }

        enemy_move[0] = new Vector3(0f, 0f, -1f);
        enemy_move[1] = new Vector3(1f, 0f, 0f);
        enemy_move[2] = new Vector3(-1f, 0f, 0f);
        enemy_move[3] = new Vector3(1f, 0f, -1f);
        enemy_move[4] = new Vector3(-1f, 0f, -1f);

        attack_switch = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time_count += Time.deltaTime;


        if (time_count >= 2f)
        {
            if (attack_switch == true)
            {
                move_enemy_attack[3].transform.position = transform.position;
                move_enemy_attack[4].transform.position = transform.position;

                move_enemy_attack[3].SetActive(true);
                move_enemy_attack[4].SetActive(true);

                attack_switch = false;
            }
            else
            {
                move_enemy_attack[0].transform.position = transform.position;
                move_enemy_attack[1].transform.position = transform.position;
                move_enemy_attack[2].transform.position = transform.position;

                move_enemy_attack[0].SetActive(true);
                move_enemy_attack[1].SetActive(true);
                move_enemy_attack[2].SetActive(true);

                attack_switch = true;
            }

            time_count = 0;
        }

        if (attack_switch == true)
        {
            move_enemy_attack[0].transform.position += enemy_move[0].normalized * 1;
            move_enemy_attack[1].transform.position += enemy_move[1].normalized * 1;
            move_enemy_attack[2].transform.position += enemy_move[2].normalized * 1;  
        }
        else
        {
            move_enemy_attack[3].transform.position += enemy_move[3].normalized * 1;
            move_enemy_attack[4].transform.position += enemy_move[4].normalized * 1;
        }
    }
}
