using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Player_Exp_Get : MonoBehaviour
{
    // 取得経験値
    private int exp = 0;
    // 倒したときに手に入る経験値（レベル１）
    private int[] get_exp = new int[6];
    // プレイヤーのレベルを管理しているスクリプトを取得
    private Player_Level_Manager player_level = null;
    // 現在のコイン(経験値)
    // コイン取得数表示のテキスト
    [SerializeField] private TMP_Text now_coin = null;


    // Start is called before the first frame update
    void Start()
    {
        player_level = gameObject.GetComponent<Player_Level_Manager>();

        // ビルレベルごとの経験値
        get_exp[0] = 5;
        get_exp[1] = 20;
        get_exp[2] = 50;
        get_exp[3] = 200;
        get_exp[4] = 500;
        get_exp[5] = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        now_coin.text = "Coin:" + exp;
        SetCoin();
    }

    /// <summary>
    /// 経験値を入れる
    /// </summary>
    /// <param name="bill_level"></param>
    public void SetExp(int bill_level) 
    {
        exp += get_exp[bill_level];
    }

    public void SetCoin()
    {
        Variable_Manager.Instance.GetSetCoin = exp;
    }

    private void Reset()
    {
        now_coin = GameObject.Find("Coin").GetComponent<TMP_Text>();
    }

    /// <summary>
    /// プレイヤーの経験値
    /// </summary>
    /// <returns></returns>
    public int GetExp() { return exp; }
}
