using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Exp_Get : MonoBehaviour
{
    // 取得経験値
    private int exp = 0;
    // 時間加算用経験値
    private int time_exp = 0;

    // デバック用
    [SerializeField] private GameObject text_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bill_Level_1")
        {
            exp += 1;
            time_exp += 1;
        }

        if (other.gameObject.tag == "Bill_Level_2")
        {
            exp += 2;
            time_exp += 2;
        }

        if (other.gameObject.tag == "Bill_Level_3")
        {
            exp += 3;
            time_exp += 3;
        }

        if (other.gameObject.tag == "Bill_Level_4")
        {
            exp += 4;
            time_exp += 4;
        }

        if (other.gameObject.tag == "Bill_Level_5")
        {
            exp += 5;
            time_exp += 5;
        }

        //Text _text = text_.GetComponent<Text>();
        //_text.text = "" + exp;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bill_Level_1")
        {
            exp += 1;
            time_exp += 1;
        }

        if (collision.gameObject.tag == "Bill_Level_2")
        {
            exp += 2;
            time_exp += 2;
        }

        if (collision.gameObject.tag == "Bill_Level_3")
        {
            exp += 3;
            time_exp += 3;
        }

        if (collision.gameObject.tag == "Bill_Level_4")
        {
            exp += 4;
            time_exp += 4;
        }

        if (collision.gameObject.tag == "Bill_Level_5")
        {
            exp += 5;
            time_exp += 5;
        }
    }

    /// <summary>
    /// プレイヤーの経験値
    /// </summary>
    /// <returns></returns>
    public int GetExp() { return exp; }

    /// <summary>
    /// 時間の経験値
    /// </summary>
    /// <returns></returns>
    public int GetTimeExp() { return time_exp; }

    /// <summary>
    /// 時間の経験値をリセット
    /// </summary>
    public void TimeExpReset() 
    {
        time_exp = 0;
    }
}
