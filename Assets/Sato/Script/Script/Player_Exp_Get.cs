using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Exp_Get : MonoBehaviour
{
    // 取得経験値
    private int exp = 0;
    // レベルマネージャーオブジェクトを取得
    [SerializeField] private GameObject game_manager;
    // プレイヤーのレベルを管理しているスクリプトを取得
    private Player_Level_Manager player_level;
    // 現在のコイン(経験値)
    [SerializeField] private GameObject text_;

    // Start is called before the first frame update
    void Start()
    {
        player_level = game_manager.GetComponent<Player_Level_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        Text _text = text_.GetComponent<Text>();
        _text.text = "Coin:" + exp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bill_Level_1")
        {
            exp += 1;
        }

        if (other.gameObject.tag == "Bill_Level_2")
        {
            exp += 2;
        }

        if (other.gameObject.tag == "Bill_Level_3")
        {
            exp += 3;
        }

        if (other.gameObject.tag == "Bill_Level_4")
        {
            exp += 4;
        }

        if (other.gameObject.tag == "Bill_Level_5")
        {
            exp += 5;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bill_Level_1" && player_level.GetLevel() == 1)
        {
            exp += 1;
        }

        if (collision.gameObject.tag == "Bill_Level_2" && player_level.GetLevel() == 2)
        {
            exp += 2;
        }

        if (collision.gameObject.tag == "Bill_Level_3" && player_level.GetLevel() == 3)
        {
            exp += 3; 
        }

        if (collision.gameObject.tag == "Bill_Level_4" && player_level.GetLevel() == 4)
        {
            exp += 4;
        }

        if (collision.gameObject.tag == "Bill_Level_5" && player_level.GetLevel() == 5)
        {
            exp += 5;
        }
    }

    public void SetPlayerExp()
    {
        Variable_Manager.Instance.PlayerExp = exp;
    }

    /// <summary>
    /// プレイヤーの経験値
    /// </summary>
    /// <returns></returns>
    public int GetExp() { return exp; }
}
