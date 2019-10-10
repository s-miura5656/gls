using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_manager : MonoBehaviour
{
    [SerializeField] private GameObject enemy_under;
    [SerializeField] private GameObject enemy_midlle;
    [SerializeField] private GameObject enemy_top;
    private bool under_down;
    private bool midlle_down;
    // Start is called before the first frame update
    void Start()
    {
        under_down = false;
        midlle_down = true;
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
                    new Vector3(enemy_midlle.transform.position.x, enemy_midlle.transform.position.y - 5f, enemy_midlle.transform.position.z);
                // 上段を中段へ下げる
                enemy_top.transform.position = 
                    new Vector3(enemy_top.transform.position.x, enemy_top.transform.position.y - 5f, enemy_top.transform.position.z);

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
                    new Vector3(enemy_top.transform.position.x, enemy_top.transform.position.y - 5f, enemy_top.transform.position.z);

                midlle_down = true;
            }
        }
    }
}
