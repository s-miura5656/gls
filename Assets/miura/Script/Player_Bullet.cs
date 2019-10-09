using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    // プレイヤーを追従するオブジェクトを入れるためのリスト
    private List<GameObject> player_bullet_list = new List<GameObject>();
    // プレイヤーを追従するオブジェクト
    private GameObject player_bullet;
    // プレイヤーを追従するオブジェクトのコピー
    private GameObject player_bullet_copy;
    
    // Start is called before the first frame update
    void Start()
    {
        player_bullet = (GameObject)Resources.Load("Player_Bullet");
        PlayerBulletGenerator();
        PlayerBulletGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerBulletGenerator()
    {
        player_bullet_copy = Instantiate(player_bullet, transform.position, transform.rotation);

        player_bullet_list.Add(player_bullet_copy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            PlayerBulletGenerator();
        }
    }
}
