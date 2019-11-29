using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bill_Level_manager : MonoBehaviour
{
    // 各レベルのゲームオブジェクトを格納する
    [SerializeField] private GameObject[] bill_lv_zero = null;
    [SerializeField] private GameObject[] bill_lv_one = null;
    [SerializeField] private GameObject[] bill_lv_two = null;
    [SerializeField] private GameObject[] bill_lv_three = null;
    [SerializeField] private GameObject[] bill_lv_four = null;
    [SerializeField] private GameObject[] bill_lv_five = null;

    // 各レベルのBOXコライダーを取得
    [SerializeField] private BoxCollider[] collider_zero = null;
    [SerializeField] private BoxCollider[] collider_one = null;
    [SerializeField] private BoxCollider[] collider_two = null;
    [SerializeField] private BoxCollider[] collider_three = null;
    [SerializeField] private BoxCollider[] collider_four = null;
    [SerializeField] private BoxCollider[] collider_five = null;

    private void Start()
    {
        
    }

    /// <summary>
    /// ビルが破壊可能かどうか
    /// </summary>
    public void BillPossible(int player_level) 
    {
        if (player_level >= 2)
        {
            for (int i = 0; i < collider_zero.Length; i++)
            {
                if (collider_zero[i].isTrigger != true)
                {
                    collider_zero[i].isTrigger = true;
                }
                else
                {
                    break;
                }
            }
        }

        if (player_level >= 4)
        {
            for (int i = 0; i < collider_one.Length; i++)
            {
                if (collider_one[i].isTrigger != true)
                {
                    collider_one[i].isTrigger = true;
                }
                else
                {
                    break;
                }
            }
        }

        if (player_level >= 6)
        {
            for (int i = 0; i < collider_two.Length; i++)
            {
                if (collider_two[i].isTrigger != true)
                {
                    collider_two[i].isTrigger = true;
                }
                else
                {
                    break;
                }
            }
        }

        if (player_level >= 8)
        {
            for (int i = 0; i < collider_three.Length; i++)
            {
                if (collider_three[i].isTrigger != true)
                {
                    collider_three[i].isTrigger = true;
                }
                else
                {
                    break;
                }
            }
        }

        if (player_level >= 10)
        {
            for (int i = 0; i < collider_four.Length; i++)
            {
                if (collider_four[i].isTrigger != true)
                {
                    collider_four[i].isTrigger = true;
                }
                else
                {
                    break;
                }
            }
        }

        if (player_level >= 12)
        {
            for (int i = 0; i < collider_five.Length; i++)
            {
                if (collider_five[i].isTrigger != true)
                {
                    collider_five[i].isTrigger = true;
                }
                else
                {
                    break;
                }
            }
        }
    }

    private void Reset()
    {    
        bill_lv_zero = GameObject.FindGameObjectsWithTag("Bill_Level_0");
        bill_lv_one = GameObject.FindGameObjectsWithTag("Bill_Level_1");
        bill_lv_two = GameObject.FindGameObjectsWithTag("Bill_Level_2");
        bill_lv_three = GameObject.FindGameObjectsWithTag("Bill_Level_3");
        bill_lv_four = GameObject.FindGameObjectsWithTag("Bill_Level_4");
        bill_lv_five = GameObject.FindGameObjectsWithTag("Bill_Level_5");

        collider_zero = new BoxCollider[bill_lv_zero.Length];
        collider_one = new BoxCollider[bill_lv_one.Length];
        collider_two = new BoxCollider[bill_lv_two.Length];
        collider_three = new BoxCollider[bill_lv_three.Length];
        collider_four = new BoxCollider[bill_lv_four.Length];
        collider_five = new BoxCollider[bill_lv_five.Length];


        for (int i = 0; i < bill_lv_zero.Length; i++)
        {
            collider_zero[i] = bill_lv_zero[i].GetComponent<BoxCollider>();
        }

        for (int i = 0; i < bill_lv_one.Length; i++)
        {
            collider_one[i] = bill_lv_one[i].GetComponent<BoxCollider>();
        }

        for (int i = 0; i < bill_lv_two.Length; i++)
        {
            collider_two[i] = bill_lv_two[i].GetComponent<BoxCollider>();
        }

        for (int i = 0; i < bill_lv_three.Length; i++)
        {
            collider_three[i] = bill_lv_three[i].GetComponent<BoxCollider>();
        }

        for (int i = 0; i < bill_lv_four.Length; i++)
        {
            collider_four[i] = bill_lv_four[i].GetComponent<BoxCollider>();
        }

        for (int i = 0; i < bill_lv_five.Length; i++)
        {
            collider_five[i] = bill_lv_five[i].GetComponent<BoxCollider>();
        }
    }
}
