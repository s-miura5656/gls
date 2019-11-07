using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bill_Destroy : MonoBehaviour
{
    // プレイヤーのレベルを取得するためのオブジェクト取得
    private GameObject game_manager;
    // プレイヤーのレベルのスクリプトの取得
    private Player_Level_Manager player_level_script;
    // ビルのレベル
    private int bill_level;
    // 壊れるパーティクル
    [SerializeField] private GameObject crash;
    // 生成したパーティクルを入れるための変数
    private GameObject crash_copy;
    // デバック用
    //[SerializeField] private GameObject text_;
    
    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.Find("GameManager");
        player_level_script = game_manager.GetComponent<Player_Level_Manager>();

        BillLevelSerch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (bill_level < player_level_script.GetLevel())
            {
                crash_copy = Instantiate(crash, transform.position, transform.rotation);

                crash_copy.transform.localScale *= bill_level;

                gameObject.SetActive(false);

                Vibration.Vibrate(10);
            }
        }

        //Text _text = text_.GetComponent<Text>();
        //_text.text = "" + player_level_script.GetLevel();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (bill_level == player_level_script.GetLevel())
            {
                crash_copy = Instantiate(crash, transform.position, transform.rotation);

                crash_copy.transform.localScale *= bill_level;

                gameObject.SetActive(false);

                Vibration.Vibrate(50);
            }
        }
    }

    private void BillLevelSerch() 
    {
        if (transform.tag == "Bill_Level_1")
        {
            bill_level = 1;
        }

        if (transform.tag == "Bill_Level_2")
        {
            bill_level = 2;
        }

        if (transform.tag == "Bill_Level_3")
        {
            bill_level = 3;
        }

        if (transform.tag == "Bill_Level_4")
        {
            bill_level = 4;
        }

        if (transform.tag == "Bill_Level_5")
        {
            bill_level = 5;
        }
    }
}
