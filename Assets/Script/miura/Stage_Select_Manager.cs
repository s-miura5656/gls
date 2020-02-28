using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Stage_Select_Manager : MonoBehaviour
{
    // ステージセレクトのボタン
    [Header("ステージセレクトボタン")] [SerializeField] private GameObject[] stage_button = { null };
    // ☆マークのオブジェクト取得
    [Header("☆マークのイメージ")] [SerializeField] private Image[] star_image = { null };
    // 破壊率ゲージ　親
    [Header("最大破壊率を表示するゲージ(親)")] [SerializeField] private RectTransform[] gage_parent = { null };
    // 破壊率ゲージ　子
    [Header("最大破壊率を表示するゲージ(子)")] [SerializeField] private Image[] gage_child = { null };
    // ゲームレベルのスクリプト取得
    [Header("ゲームレベルデータ")] [SerializeField] private GameLevelData game_level_script = null;
    // ボタンのロック画面
    [Header("ボタンのロック画面")] [SerializeField] private GameObject[] button_lock = { null };
    // Newマークのオブジェクト
    [Header("Newマーク")] [SerializeField] private GameObject[] new_mark = { null };
    // PlayボタンのNewマーク
    [Header("PlayButtonのNewマーク")] [SerializeField] private GameObject play_new_mark = null;
    // ステージセレクトのボタンの基準位置
    [SerializeField]private Vector3 base_button_pos = new Vector3(-430f, -100f, 0f);
    // ボタンのX軸移動量
    [SerializeField] private float dist_x = 430f;
    // ボタンのY軸移動量
    [SerializeField] private float dist_y = -450f;
    // ボタンの行
    private int button_line = 2;
    // 目標を達成してるかどうかのフラグ
    private bool[] achievement_flag = { false };

    [System.Obsolete]
    private void Awake()
    {
        AchievementRateChaker();
        SetStarColor();
        SetTarget();
        SetButton(Color.red);
        SetLockDisplay();
        SetNewMark();
    }

    [System.Obsolete]
    private void Reset()
    {
        stage_button = GameObject.FindGameObjectsWithTag("StageButton");
        star_image = new Image[stage_button.Length];
        gage_parent = new RectTransform[stage_button.Length];
        gage_child = new Image[stage_button.Length];
        button_lock = new GameObject[stage_button.Length];
        new_mark = new GameObject[stage_button.Length];

        play_new_mark = GameObject.Find("Play").transform.FindChild("Play_New").gameObject;

        for (int i = 0; i < stage_button.Length; i++)
        {
            star_image[i] = stage_button[i].transform.FindChild("Star").gameObject.GetComponent<Image>();
            gage_parent[i] = stage_button[i].transform.FindChild("Gage").gameObject.GetComponent<RectTransform>();
            gage_child[i] = gage_parent[i].transform.FindChild("Inside").gameObject.GetComponent<Image>();
            button_lock[i] = stage_button[i].transform.FindChild("LockDisplay").gameObject;
            new_mark[i] = stage_button[i].transform.FindChild("New_Image").gameObject;
        }

        SetButtonName();
        SetButtonColor();
    }

    private void OnValidate()
    {
        SetButtonPos();
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
            GameObject button_lock = stage_button[i].transform.FindChild("LockDisplay").gameObject;
            TextMeshProUGUI lock_text = button_lock.transform.FindChild("Stage_Number").gameObject.GetComponent<TextMeshProUGUI>();

            stage_button[i].name = $"Stage_{i + 1}";
            text.text = $"STAGE {(i + 1)}";
            lock_text.text = $"STAGE { i }";
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
            text.text = $"{ (int)PlayerPrefs.GetFloat($"Stage_{ i }_DestructionRateMax") } / { game_level_script.DestructionTarget[i] } %";

            // 目標メモリの設定
            RectTransform target_gage = button_target.transform.FindChild("Inside").gameObject.GetComponent<RectTransform>();
            RectTransform target_bar = target_gage.transform.FindChild("Goal_Bar").gameObject.GetComponent<RectTransform>();

            target_bar.localPosition = new Vector3((target_gage.sizeDelta.x / 100f) * game_level_script.DestructionTarget[i], 0f, 0f);
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
            else if (i >= stage_number * 2 && i < stage_number * 3)
            {
                stage_button[i].GetComponent<Image>().color = new Color(187f / base_rgb, 111f / base_rgb, 242f / base_rgb);
                button_image.GetComponent<Image>().color = new Color(229f / base_rgb, 201f / base_rgb, 250f / base_rgb);
            }
            else if (i >= stage_number * 3 && i < stage_number * 4)
            {
                stage_button[i].GetComponent<Image>().color = new Color(231f / base_rgb, 125f / base_rgb, 211f / base_rgb);
                button_image.GetComponent<Image>().color = new Color(241f / base_rgb, 162f / base_rgb, 227f / base_rgb);
            }
            else if (i >= stage_number * 4 && i < stage_number * 5)
            {
                stage_button[i].GetComponent<Image>().color = new Color(230f / base_rgb, 230f / base_rgb, 125f / base_rgb);
                button_image.GetComponent<Image>().color = new Color(255f / base_rgb, 255f / base_rgb, 185f / base_rgb);
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
            if (achievement_flag[i])
            {
                star_image[i].color = Color.white;
            }
            else
            {
                star_image[i].color = Color.black;
            }
        }
    }

    /// <summary>
    /// 目標破壊率に応じてボタンのゲージ、☆を変更
    /// </summary>
    private void SetButton(Color target_clear_color) 
    {
        for (int i = 0; i < gage_child.Length; i++)
        {
            gage_child[i].fillAmount = ((gage_parent[i].sizeDelta.x / 100f) * (int)PlayerPrefs.GetFloat($"Stage_{ i }_DestructionRateMax")) / gage_parent[i].sizeDelta.x;

            if (achievement_flag[i])
            {
                star_image[i].color = Color.white;
                gage_child[i].color = target_clear_color;
            }
        }
    }

    /// <summary>
    /// 破壊率の目標を達成しているかどうかを確認する
    /// </summary>
    private void AchievementRateChaker() 
    {
        achievement_flag = new bool[stage_button.Length];

        for (int i = 0; i < stage_button.Length; i++)
        {
            if (PlayerPrefs.GetFloat($"Stage_{ i }_DestructionRateMax") >= game_level_script.DestructionTarget[i])
            {
                achievement_flag[i] = true;

                if (PlayerPrefs.GetInt($"AchievementRateFlag_{ i }") != 1)
                    PlayerPrefs.SetInt($"AchievementRateFlag_{ i }", Convert.ToInt32(achievement_flag[i]));
            }
        }
    }


    private void SetLockDisplay() 
    {
        if (button_lock[0].activeSelf)
            button_lock[0].SetActive(false);

        for (int i = 1; i < button_lock.Length; i++)
        {
            if (achievement_flag[i - 1])
            {
                if(button_lock[i].activeSelf)
                   button_lock[i].SetActive(false);
            }
        }
    }

    private void SetNewMark() 
    {
        for (int i = 1; i < new_mark.Length; i++)
        {
            if (PlayerPrefs.GetFloat($"Stage_{ i }_DestructionRateMax") == 0f && !button_lock[i].activeSelf)
            {
                new_mark[i].SetActive(true);
                play_new_mark.SetActive(true);
                break;
            }
        }
    }

    public bool[] AchievementFlag 
    {
        get { return achievement_flag; }
    }
}
