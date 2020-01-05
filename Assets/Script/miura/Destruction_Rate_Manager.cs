using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Destruction_Rate_Manager : MonoBehaviour
{
    // 破壊できるオブジェクトの総数
    private float base_number = 0;
    // 現在の破壊できるオブジェクト数
    private float now_number = 0;
    // 最終的に表示させる破壊率
    private float last_destruction_rate = 0f;
    // 現在の破壊率を表示するテキスト
    [SerializeField] private TextMeshProUGUI destruction_rate = null;
    // 自己ベストの破壊率を表示するテキスト
    [SerializeField] private TextMeshProUGUI hi_score = null;
    // 時間を管理しているスクリプトの取得
    private Time_Manager time_script = null;

    // Start is called before the first frame update
    void Start()
    {
        time_script = gameObject.GetComponent<Time_Manager>();

        HiScoreLoad();

        Check();

        DestructionRateCalculation();
    }

    // Update is called once per frame
    void Update()
    {
        destruction_rate.text = last_destruction_rate.ToString("f2");
    }

    /// <summary>
    /// タグのついたオブジェクトを探す
    /// </summary>
    private void Check()
    {
        GameObject[] tag_objects; 

        for (int i = 0; i < 6; i++)
        {
            tag_objects = GameObject.FindGameObjectsWithTag("Bill_Level_" + i);
            now_number += tag_objects.Length;

            if (tag_objects.Length == 0)
            {
                Debug.Log("Bill_Level_" + i + "タグがついたオブジェクトはありません");
            }
        }

        base_number = now_number;
    }

    /// <summary>
    /// 破壊率の計算
    /// </summary>
    private void DestructionRateCalculation() 
    {
        last_destruction_rate = 100f - (now_number / base_number) * 100f;
    }

    /// <summary>
    /// 各ステージのレベル毎の最大破壊率
    /// </summary>
    private void HiScoreLoad() 
    {
        hi_score.text = PlayerPrefs.GetFloat("Stage_" + Variable_Manager.Instance.Serect_Stage + "_DestructionRateMax_" + Variable_Manager.Instance.GetSetStageLevel).ToString("f2") + " %";
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
}
