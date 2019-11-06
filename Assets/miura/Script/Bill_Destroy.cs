using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bill_Destroy : MonoBehaviour
{
    // ビルが壊れるアニメーション
    private GameObject bill_destroy;
    // ビルのアニメの取得
    private Animator bill_destroy_anime;
    // プレイヤーのレベルを取得するためのオブジェクト取得
    [SerializeField] private GameObject game_manager;
    // プレイヤーのレベルのスクリプトの取得
    private Player_Level_Manager player_level_script;
    // ビルのレベル
    private int bill_level;
    // 回転する角度
    private float[] euler = new float[4] { 0f, 90f, 180f, 270f };
    // 壊れるパーティクル
    [SerializeField] private GameObject crash;
    // デバック用
    [SerializeField] private GameObject text_;
    // ビル内部ボックス
    //[SerializeField] private GameObject[] boxs;

    // Start is called before the first frame update
    void Start()
    {
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
                //Instantiate(crash, transform.position, transform.rotation);

                gameObject.SetActive(false);

                //foreach (GameObject box in boxs)
                //{
                //    // コライダーを有効にする
                //    box.GetComponent<BoxCollider>().isTrigger = false;    
                //    box.GetComponent<Rigidbody>().useGravity = true;
                //}
            }
        }

        Text _text = text_.GetComponent<Text>();
        _text.text = "" + player_level_script.GetLevel();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (bill_level == player_level_script.GetLevel())
            {
                //Instantiate(crash, transform.position, transform.rotation);

                gameObject.SetActive(false);
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

        //if (transform.tag == "Bill_Level_4")
        //{
        //    bill_level = 4;
        //}

        //if (transform.tag == "Bill_Level_5")
        //{
        //    bill_level = 5;
        //}
    }
}
