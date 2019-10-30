using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Exp_Get : MonoBehaviour
{
    // 取得経験値
    private int exp = 0;
    // デバック用
    [SerializeField] private GameObject text_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Text _text = text_.GetComponent<Text>();
        //_text.text = "" + exp;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bill_Level_1")
        {
            exp += 1;
        }

        if (collision.gameObject.tag == "Bill_Level_2")
        {
            exp += 2;
        }

        if (collision.gameObject.tag == "Bill_Level_3")
        {
            exp += 3;
        }
    }

    /// <summary>
    /// プレイヤーの経験値
    /// </summary>
    /// <returns></returns>
    public int Exp() { return exp; }
}
