using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Player_Exp_Get : MonoBehaviour
{
    // 取得経験値
    private int exp = 0;
    // 破壊した時に手に入るコイン
    private int[] coin = new int [6];
    // 今回のゲームで取得したコイン
    private int get_coin = 0;
    // 倒したときに手に入る経験値（レベル１）
    private int[] get_exp = new int[6];
    // プレイヤーのレベルを管理しているスクリプトを取得
    private Player_Level_Manager player_level = null;
    // コイン取得数表示のテキスト
    [SerializeField] private TMP_Text now_coin = null;
    // 時間を管理しているスクリプト取得
    private Time_Manager time_script = null;

    // Start is called before the first frame update
    void Start()
    {
        player_level = gameObject.GetComponent<Player_Level_Manager>();

        // ビルレベルごとの経験値
        get_exp[0] = 5;
        get_exp[1] = 25;
        get_exp[2] = 50;
        get_exp[3] = 550;
        get_exp[4] = 1100;
        get_exp[5] = 3000;

        coin[0] = 1;
        coin[1] = 3;
        coin[2] = 5;
        coin[3] = 10;
        coin[4] = 30;
        coin[5] = 50;

    }

    // Update is called once per frame
    void Update()
    {
        SetCoin();
        now_coin.text = "Coin:" + get_coin;
    }

    /// <summary>
    /// 経験値を入れる
    /// </summary>
    /// <param name="bill_level"></param>
    public void SetExp(int bill_level) 
    {
        exp += get_exp[bill_level];
        get_coin += coin[bill_level];
    }

    public void SetCoin()
    {
        Variable_Manager.Instance.GetSetCoin = get_coin;
    }


    private void Reset()
    {
        now_coin = GameObject.Find("Coin").GetComponent<TMP_Text>();
        time_script = gameObject.GetComponent<Time_Manager>();
    }

    /// <summary>
    /// プレイヤーの経験値
    /// </summary>
    /// <returns></returns>
    public int GetExp() { return exp; }

    public int GetCoin(int bill_level) { return coin[bill_level]; }
}
