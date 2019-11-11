using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction_Rate_Manager : MonoBehaviour
{
    private GameObject[] tag_objects;
    // 破壊できるオブジェクトの総数
    private int base_number = 0;
    private int now_number = 0;
    private float destruction_rate = 0f; 
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            Check("Bill_Level_" + i);
            now_number += tag_objects.Length;
        }

        base_number = now_number;

        DestructionRateCalculation();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(destruction_rate);
    }

    private void Check(string tagname)
    {
        tag_objects = GameObject.FindGameObjectsWithTag(tagname);

        if (tag_objects.Length == 0)
        {
            Debug.Log(tagname + "タグがついたオブジェクトはありません");
        }
    }

    /// <summary>
    /// 破壊率の計算
    /// </summary>
    private void DestructionRateCalculation() 
    {
        destruction_rate = (now_number / base_number) * 100f;
    }


    /// <summary>
    /// 破壊率計算用の関数、オブジェクトが破壊されたら減らしていく
    /// </summary>
    public void DownNowRate() 
    {
        now_number--;

        DestructionRateCalculation();
    }

}
