using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Bullet : MonoBehaviour
{
    // プレイヤーを追従するオブジェクト
    [SerializeField] private GameObject[] player_bullets;
    

    private int number;
    // Start is called before the first frame update
    void Start()
    {
        number = 1;
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            if (number < 4)
            {
                number++;
                player_bullets[number].SetActive(true);
            }

            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "enemy")
        {
            if (number > -1)
            {
                player_bullets[number].SetActive(false);
                number--;
            }
            else
            {
                Debug.Log("game_over");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy_attack")
        {
            if (number > -1)
            {
                player_bullets[number].SetActive(false);
                number--;
            }
            else
            {
                Debug.Log("game_over");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
