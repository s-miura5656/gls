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
    private int get_exp = 10;
    private int zero_get_exp = 5;
    // プレイヤーのレベルを管理しているスクリプトを取得
    private Player_Level_Manager player_level = null;
    // 現在のコイン(経験値)
    [SerializeField] private GameObject coin_text = null;
    // コイン取得数表示のテキスト
    private TextMeshProUGUI now_coin = null;


    // Start is called before the first frame update
    void Start()
    {
        player_level = gameObject.GetComponent<Player_Level_Manager>();
        now_coin = coin_text.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        now_coin.text = "Coin:" + exp;
        SetCoin();
    }

    public void SetExp(int bill_level) 
    {
        if (bill_level > 0)
        {
            exp += get_exp * bill_level;
        }

        if(bill_level == 0)
        {
            exp += zero_get_exp;
        }
    }

    public void SetCoin()
    {
        Variable_Manager.Instance.GetSetCoin = exp;
    }

    private void Reset()
    {
        coin_text = GameObject.Find("Coin");
    }

    /// <summary>
    /// プレイヤーの経験値
    /// </summary>
    /// <returns></returns>
    public int GetExp() { return exp; }
}
