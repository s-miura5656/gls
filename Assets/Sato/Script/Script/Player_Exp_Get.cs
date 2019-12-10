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
    private int[] coin = new int[6];
    // 今回のゲームで取得したコイン
    private int get_coin = 0;
    // 倒したときに手に入る経験値（レベル１）
    private int[] get_exp = new int[6];
    // ゲームレベルデータの取得
    [SerializeField] private GameLevelData level_data_script = null;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < get_exp.Length; i++)
        {
            get_exp[i] = level_data_script.BillGetExp[i];
        }

        for (int i = 0; i < coin.Length; i++)
        {
            coin[i] = level_data_script.BillGetCoin[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetCoin();
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

    /// <summary>
    /// 今回のゲームで取得したコイン
    /// </summary>
    public void SetCoin()
    {
        Variable_Manager.Instance.GetSetCoin = get_coin;
    }

    /// <summary>
    /// プレイヤーの経験値
    /// </summary>
    /// <returns></returns>
    public int PlayerExp 
    {
        get { return exp; }
        set { exp = value; }
    }

    /// <summary>
    /// コインの取得
    /// </summary>
    /// <param name="bill_level"></param>
    /// <returns></returns>
    public int GetCoin(int bill_level) { return coin[bill_level]; }
}
