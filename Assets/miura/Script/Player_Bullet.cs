using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    // プレイヤーを追従するオブジェクト
    [SerializeField] private GameObject[] player_bullets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            for (int i = 0; i < 5; i++)
            {
                if (player_bullets[i].activeSelf == false)
                {
                    player_bullets[i].SetActive(true);
                    break;
                }
            }
        }
    }
}
