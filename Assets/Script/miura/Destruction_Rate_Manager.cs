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
    // 現在の破壊率を表示するオブジェクトのRectTransform
    [SerializeField] private RectTransform dest_image_size = null;
    // 現在の破壊率を表示するテキスト
    [SerializeField] private TextMeshProUGUI destruction_rate = null;
    // ゲームレベルデータのスクリプト
    [SerializeField] private GameLevelData game_level_script = null;
    // ゲーム開始時に表示される目標破壊率
    [SerializeField] private TextMeshProUGUI target_dest_rate = null;
    // 時間を管理しているスクリプトの取得
    private Time_Manager time_script = null;
    // 目標破壊率を表示するかどうかのフラグ
    private bool target_dest_rate_flag = true;
    // 目標破壊率のみの時の黒枠のサイズ
    private Vector2 image_size_max = new Vector2(350f, 65f);
    private Vector2 image_size_min = new Vector2(260f, 65f);

    // Start is called before the first frame update
    void Start()
    {
        time_script = gameObject.GetComponent<Time_Manager>();

        Check();

        DestructionRateCalculation();

        // 目標破壊率表示するかどうか
        if (PlayerPrefs.GetFloat($"Stage_{ Variable_Manager.Instance.Serect_Stage }_DestructionRateMax") < game_level_script.DestructionTarget[Variable_Manager.Instance.Serect_Stage])
        {
            target_dest_rate_flag = true;
            dest_image_size.sizeDelta = image_size_max;
        }
        else
        {
            target_dest_rate_flag = false;
            dest_image_size.sizeDelta = image_size_min;
        }

        target_dest_rate.text = game_level_script.DestructionTarget[Variable_Manager.Instance.Serect_Stage] + " %";
    }

    // Update is called once per frame
    void Update()
    {
        // 破壊率の表示
        if (target_dest_rate_flag)
        {
            destruction_rate.text = last_destruction_rate.ToString("f2") + " / " + game_level_script.DestructionTarget[Variable_Manager.Instance.Serect_Stage] + " %";
        }
        else
        {
            destruction_rate.text = last_destruction_rate.ToString("f2") + " %";
        }
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
        time_script.DestructionRate(last_destruction_rate);
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
    /// 破壊率の記録
    /// </summary>
    public void SetDestructionRate() 
    {
        Variable_Manager.Instance.GetSetDestructionRate = last_destruction_rate;
    }

    public float GetDestRate 
    {
        get { return last_destruction_rate; }
    }
}
