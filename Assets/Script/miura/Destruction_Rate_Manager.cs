using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Destruction_Rate_Manager : MonoBehaviour
{
    private GameObject[] tag_objects;
    // 破壊できるオブジェクトの総数
    private float base_number = 0;
    // 現在の破壊できるオブジェクト数
    private float now_number = 0;
    // 全体の割合（破壊率）
    private float base_destruction_rate = 0f;
    // 最終的に表示させる破壊率
    private float last_destruction_rate = 0f;
    // テキストオブジェクトのテキストコンポーネント
    [SerializeField] private TextMeshProUGUI destruction_rate_text = null;
    // 時間を管理しているスクリプトの取得
    private Time_Manager time_script = null;

    // Start is called before the first frame update
    void Start()
    {
        time_script = gameObject.GetComponent<Time_Manager>();

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
        destruction_rate_text.text = last_destruction_rate.ToString("f2");
        //SetDestructionRate();
    }

    /// <summary>
    /// タグのついたオブジェクトを探す
    /// </summary>
    /// <param name="tagname"></param>
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
        base_destruction_rate = (now_number / base_number) * 100f;

        last_destruction_rate = 100f - base_destruction_rate;
    }

    /// <summary>
    /// 破壊率計算用の関数、オブジェクトが破壊されたら減らしていく
    /// </summary>
    public void DownNowRate() 
    {
        if (time_script.GetGamePlayState)
        {
            now_number--;
        }

        DestructionRateCalculation();
    }

    /// <summary>
    /// 最終的な破壊率
    /// </summary>
    public void SetDestructionRate() 
    {
        Variable_Manager.Instance.GetSetDestructionRate = last_destruction_rate;
    }

    private void OnDestroy()
    {
        SetDestructionRate();
    }
}
