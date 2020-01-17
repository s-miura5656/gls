using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_Loading : MonoBehaviour
{
    // ロード画面のオブジェクト
    [SerializeField] private GameObject load_screen = null;
    // 目標破壊率を表示するオブジェクト
    [SerializeField] private GameObject target_dest_rate = null;
    // ゲームのカウントダウン開始
    private bool count_down_start = false;
    // 時間
    private float count = 0;
    // ロード画面が終了する時間
    private float load_end = 2f;
    // 破壊率の目標を表示する時間
    private float shoe_target_time = 3f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (count_down_start)
            return;

        count += Time.deltaTime;

        if (count > load_end)
        {
            if (/*Variable_Manager.Instance.Serect_Stage*/ 2 != 1)
            {
                DisplayOfTargetDestRate();
            }
            else
            {
                LodingEnd();
            }
        }
    }

    /// <summary>
    /// ロード画面の終了
    /// </summary>
    private void LodingEnd() 
    {
        load_screen.SetActive(false);
        count_down_start = true;
    }

    /// <summary>
    /// 目標破壊率の表示
    /// </summary>
    private void DisplayOfTargetDestRate() 
    {
        if (load_screen.activeSelf)
            load_screen.SetActive(false);

        if (!target_dest_rate.activeSelf)
            target_dest_rate.SetActive(true);

        if (count > (load_end + shoe_target_time))
        {
            target_dest_rate.SetActive(false);
            count_down_start = true;
        }
    }

    /// <summary>
    /// ゲームメインのカウントダウンを開始するフラグ
    /// </summary>
    public bool GetCountDownStart 
    { 
        get { return count_down_start; } 
    }
}
