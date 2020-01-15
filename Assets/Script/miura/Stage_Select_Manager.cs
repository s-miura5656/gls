using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stage_Select_Manager : MonoBehaviour
{
    // ステージセレクトのボタン
    [Header("ステージセレクトボタン")] [SerializeField] private GameObject[] stage_button = { null };
    // ☆マークのオブジェクト取得
    [Header("☆マークのオブジェクト")] [SerializeField]private GameObject[] star_obj = { null };
    // 目標破壊率
    [SerializeField] private float[] destruction_target = { 0f };
    // ステージセレクトのボタンの基準位置
    private Vector3 base_button_pos = new Vector3(-430f, -50f, 0f);
    // ボタンのX軸移動量
    private float dist_x = 430f;
    // ボタンのY軸移動量
    private float dist_y = -450f;
    // ボタンの行
    private int button_line = 2;

    [System.Obsolete]
    private void Start()
    {
        SetStarColor();
    }

    [System.Obsolete]
    private void Reset()
    {
        stage_button = GameObject.FindGameObjectsWithTag("StageButton");
        destruction_target = new float[stage_button.Length];
        star_obj = new GameObject[stage_button.Length];

        for (int i = 0; i < stage_button.Length; i++)
        {
            destruction_target[i] = 60f;
            star_obj[i] = stage_button[i].transform.FindChild("Star").gameObject;
        }

        SetButtonPos();
        SetButtonName();
        SetTarget();
        SetButtonColor();
    }

    /// <summary>
    /// ボタンの位置を整列させる
    /// </summary>
    private void SetButtonPos() 
    {
        int x_move = 0;
        int y_down = 0;

        for (int i = 0; i < stage_button.Length; i++)
        {
            stage_button[i].transform.localPosition = base_button_pos + new Vector3(dist_x * x_move, dist_y * y_down, 0f);

            if (x_move < button_line)
            {
                x_move++;
            }
            else
            {
                x_move = 0;
                y_down++;
            }
        }
    }

    /// <summary>
    /// ボタンの名前を変える
    /// </summary>
    [System.Obsolete]
    private void SetButtonName() 
    {
        for (int i = 0; i < stage_button.Length; i++)
        {
            stage_button[i].transform.SetSiblingIndex(i);
            GameObject button_image = stage_button[i].transform.FindChild("Button_Parent").gameObject;
            TextMeshProUGUI text = button_image.GetComponentInChildren<TextMeshProUGUI>();
            stage_button[i].name = $"Stage_{i + 1}";
            text.text = $"Stage {(i + 1)}";
        }
    }

    /// <summary>
    /// ボタン毎の破壊率を設定する
    /// </summary>
    [System.Obsolete]
    private void SetTarget() 
    {
        for (int i = 0; i < stage_button.Length; i++)
        {
            GameObject button_target = stage_button[i].transform.FindChild("Gage").gameObject;
            
            // 数値の表示 
            TextMeshProUGUI text = button_target.GetComponentInChildren<TextMeshProUGUI>();
            text.text = $"{ PlayerPrefs.GetFloat($"Stage_{ Variable_Manager.Instance.Serect_Stage }_DestructionRateMax") } / {destruction_target[i]} %";

            // 目標メモリの設定
            RectTransform target_gage = button_target.transform.FindChild("Inside").gameObject.GetComponent<RectTransform>();
            RectTransform target_bar = target_gage.transform.FindChild("Goal_Bar").gameObject.GetComponent<RectTransform>();

            target_bar.localPosition = new Vector3((target_gage.sizeDelta.x / 100f) * destruction_target[i], 0f, 0f);
        }
    }

    [System.Obsolete]
    private void SetButtonColor() 
    {
        int stage_number = 9;
        float base_rgb = 255f;

        for (int i = 0; i < stage_button.Length; i++)
        {
            GameObject button_image = stage_button[i].transform.FindChild("Button_Parent").gameObject;

            if (i >= 0 && i < stage_number)
            {
                stage_button[i].GetComponent<Image>().color = new Color(136f / base_rgb, 234f / base_rgb, 159f / base_rgb);
                button_image.GetComponent<Image>().color = new Color(225f / base_rgb, 248f / base_rgb, 231f / base_rgb);
            }
            else if (i >= stage_number && i < stage_number * 2)
            {
                stage_button[i].GetComponent<Image>().color = new Color(108f / base_rgb, 126f / base_rgb, 244f / base_rgb);
                button_image.GetComponent<Image>().color = new Color(200f / base_rgb, 207f / base_rgb, 251f / base_rgb);
            }
            else if (i >= stage_number * 2 && i < stage_number * 3 - 3)
            {
                stage_button[i].GetComponent<Image>().color = new Color(187f / base_rgb, 111f / base_rgb, 242f / base_rgb);
                button_image.GetComponent<Image>().color = new Color(229f / base_rgb, 201f / base_rgb, 250f / base_rgb);
            }
        }
    }

    /// <summary>
    /// 星の色を変える
    /// </summary>
    [System.Obsolete]
    private void SetStarColor() 
    {
        for (int i = 0; i < stage_button.Length; i++)
        {
            if (PlayerPrefs.GetFloat($"Stage_{ Variable_Manager.Instance.Serect_Stage }_DestructionRateMax") > destruction_target[i])
            {
                star_obj[i].GetComponent<Image>().color = new Color(1f, 1f, 1f);
            }
            else
            {
                star_obj[i].GetComponent<Image>().color = new Color(0f, 0f, 0f);
            }
        }
    }
}
