using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_manager : MonoBehaviour
{
    // プレイヤーを追従するオブジェクト
    [SerializeField] private GameObject[] player_bullets;
    [SerializeField] private GameObject enemy_under;
    [SerializeField] private GameObject enemy_midlle;
    [SerializeField] private GameObject enemy_top;
    private bool under_down;
    private bool midlle_down;
    private bool top_down;
    private int number;
    [SerializeField] private float down_dist;
    // Start is called before the first frame update
    void Start()
    {
        under_down = false;
        midlle_down = true;
        top_down = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (under_down == false)
        {
            if (enemy_under.activeSelf == false)
            {
                // 中段を下段へ下げる
                enemy_midlle.transform.position = 
                    new Vector3(enemy_midlle.transform.position.x, enemy_midlle.transform.position.y - down_dist, enemy_midlle.transform.position.z);
                // 上段を中段へ下げる
                enemy_top.transform.position = 
                    new Vector3(enemy_top.transform.position.x, enemy_top.transform.position.y - down_dist, enemy_top.transform.position.z);

                under_down = true;
                midlle_down = false;
            } 
        }

        if (midlle_down == false)
        {
            if (enemy_midlle.activeSelf == false)
            {
                // 中段を下段へ下げる
                enemy_top.transform.position = 
                    new Vector3(enemy_top.transform.position.x, enemy_top.transform.position.y - down_dist, enemy_top.transform.position.z);

                midlle_down = true;
                top_down = false;
            }   
        }

        if (top_down == false)
        {
            if (enemy_top.activeSelf == false)
            {
                top_down = true;
                gameObject.SetActive(false);
            }
        }
        
    }
}
