using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bill_Level_manager : MonoBehaviour
{
    // プレイヤーレベルの情報を持っているスクリプト
    private Player_Level_Manager script_player;
    // ビル破壊可能かどうか判別するためのステート
    private bool destroy_possible_state;
    // ビルのレベル
    private int bill_level = 1;
    
    void Start()
    {
        script_player = gameObject.GetComponent<Player_Level_Manager>();
        BillPossible();
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーのスピードが０になったらプレイヤーレベルと比較してビルの設定を変える
        //if (script_player.GetSpeed() > 0f && destroy_possible_state == false)
        //{
        //    destroy_possible_state = true;
        //}

        //if (script_player.GetSpeed() == 0f && destroy_possible_state == true)
        //{
        //    destroy_possible_state = false;
        //}

        BillPossible();
    }

    /// <summary>
    /// ビルが破壊可能かどうか
    /// </summary>
    private void BillPossible() 
    {
        
        if (script_player.GetLevel() == 2)
        {
            // GameObject型の配列billsに、"Bill_Level_1"タグのついたオブジェクトをすべて格納
            GameObject[] bills = GameObject.FindGameObjectsWithTag("Bill_Level_0");

            // GameObject型の変数billに、billsの中身を順番に取り出す。
            // foreachは配列の要素の数だけループします。
            foreach (GameObject bill in bills)
            {
                // コライダーを有効にする
                bill.GetComponent<BoxCollider>().isTrigger = true;
            }
        }

        if (script_player.GetLevel() == 4)
        {
            // GameObject型の配列billsに、"Bill_Level_2"タグのついたオブジェクトをすべて格納
            GameObject[] bills = GameObject.FindGameObjectsWithTag("Bill_Level_1");

            // GameObject型の変数billに、billsの中身を順番に取り出す。
            // foreachは配列の要素の数だけループします。
            foreach (GameObject bill in bills)
            {
                // コライダーを有効にする
                bill.GetComponent<BoxCollider>().isTrigger = true;
            }
        }

        if (script_player.GetLevel() == 6)
        {
            // GameObject型の配列billsに、"Bill_Level_3"タグのついたオブジェクトをすべて格納
            GameObject[] bills = GameObject.FindGameObjectsWithTag("Bill_Level_2");

            // GameObject型の変数billに、billsの中身を順番に取り出す。
            // foreachは配列の要素の数だけループします。
            foreach (GameObject bill in bills)
            {
                // コライダーを有効にする
                bill.GetComponent<BoxCollider>().isTrigger = true;
            }
        }

        if (script_player.GetLevel() == 8)
        {
            // GameObject型の配列billsに、"Bill_Level_3"タグのついたオブジェクトをすべて格納
            GameObject[] bills = GameObject.FindGameObjectsWithTag("Bill_Level_3");

            // GameObject型の変数billに、billsの中身を順番に取り出す。
            // foreachは配列の要素の数だけループします。
            foreach (GameObject bill in bills)
            {
                // コライダーを有効にする
                bill.GetComponent<BoxCollider>().isTrigger = true;
            }
        }

        if (script_player.GetLevel() == 10)
        {
            // GameObject型の配列billsに、"Bill_Level_3"タグのついたオブジェクトをすべて格納
            GameObject[] bills = GameObject.FindGameObjectsWithTag("Bill_Level_4");

            // GameObject型の変数billに、billsの中身を順番に取り出す。
            // foreachは配列の要素の数だけループします。
            foreach (GameObject bill in bills)
            {
                // コライダーを有効にする
                bill.GetComponent<BoxCollider>().isTrigger = true;
            }
        }

        if (script_player.GetLevel() >= 12)
        {
            // GameObject型の配列billsに、"Bill_Level_3"タグのついたオブジェクトをすべて格納
            GameObject[] bills = GameObject.FindGameObjectsWithTag("Bill_Level_5");

            // GameObject型の変数billに、billsの中身を順番に取り出す。
            // foreachは配列の要素の数だけループします。
            foreach (GameObject bill in bills)
            {
                // コライダーを有効にする
                bill.GetComponent<BoxCollider>().isTrigger = true;
            }
        }

           
        
    }
}
