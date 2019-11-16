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
    // ヒットストップのスクリプトを取得
    private Hit_Stop_Manager hit_stop_script;
    // 破壊率を管理しているスクリプトを取得
    private Destruction_Rate_Manager destruction_rate_script;
    // ビルのレベル
    private int bill_level;
    // 壊れるパーティクル
    private GameObject crash;
    // 生成したパーティクルを入れるための変数
    private GameObject crash_copy;
    // ヒットエフェクトを入れる変数
    private GameObject hit_effect;


    // デバック用
    //[SerializeField] private GameObject text_;
    
    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.Find("GameManager");
        player_level_script = game_manager.GetComponent<Player_Level_Manager>();
        hit_stop_script = game_manager.GetComponent<Hit_Stop_Manager>();
        destruction_rate_script = game_manager.GetComponent<Destruction_Rate_Manager>();
        crash = (GameObject)Resources.Load("Collapse_Effect");
        hit_effect = (GameObject)Resources.Load("Hit_Effect_1");
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
            // ビルレベルがプレイ屋のレベルより小さいときに
            if (bill_level < player_level_script.GetLevel())
            {
                // ビル破壊時の破片のパーティクルを出す
                crash_copy = Instantiate(crash, transform.position, transform.rotation);
                // 破片のパーティクルをビルのレベルに合わせて拡大
                crash_copy.transform.localScale *= bill_level;
                // プレイヤーと当たった場所の座標
                Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);
                // プレイヤーと当たった場所にヒットエフェクト生成
                GameObject hit = Instantiate(hit_effect, hitPos, transform.rotation);
                // ヒットエフェクトのパーティクルをビルのレベルに合わせて拡大
                hit.transform.localScale *= player_level_script.GetLevel();
                // 破壊率計算用の関数
                destruction_rate_script.DownNowRate();
                // ゲームオブジェクトを非表示にする
                gameObject.SetActive(false);
                // 当たった時のバイブレーション
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
            // ビルのレベルがプレイヤーと同じか以下の時
            if (bill_level == player_level_script.GetLevel())
            {
                // ビル破壊時の破片のパーティクルを出す
                crash_copy = Instantiate(crash, transform.position, transform.rotation);
                // 破片のパーティクルをビルのレベルに合わせて拡大
                crash_copy.transform.localScale *= bill_level;

                Vector3 hitPos;

                foreach (ContactPoint point in collision.contacts)
                {
                    // プレイヤーと当たった場所の座標
                    hitPos = point.point;
                    // プレイヤーと当たった場所にヒットエフェクト生成
                    GameObject hit = Instantiate(hit_effect, hitPos, transform.rotation);
                    // ヒットエフェクトのパーティクルをビルのレベルに合わせて拡大
                    hit.transform.localScale *= player_level_script.GetLevel();
                }

                // 破壊率計算用の関数
                destruction_rate_script.DownNowRate();
                // ゲームオブジェクトを非表示にする
                gameObject.SetActive(false);
                // 当たった時のバイブレーション
                Vibration.Vibrate(40);
                // ヒットストップさせる関数の呼び出し
                //hit_stop_script.TimeStop();
            }
        }
    }

    private void BillLevelSerch() 
    {
        //for (int i = 0; i < 5; i++)
        //{
        //    if (transform.tag == "Bill_Level_" + i)
        //    {
        //        bill_level = i + 1;
        //    }
        //}

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

    public int GetBillLevel() { return bill_level; }
}
