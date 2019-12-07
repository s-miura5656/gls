using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable_Manager : SingletonMonoBehaviour<Variable_Manager>
{
    // ゲットしたコイン
    private int get_coin = 0;
    // 今回の破壊率
    private float destruction = 0f;
    // スキン番号
    private int avatar_number = 0; //save
    // 所持コイン枚数
    private int possession_coin = 0; //save
    // 振動のON,OFF
    private bool vibrate_state = true;
    // スキンデータ
    private SkinData skinData = null;

    /// <summary>
    /// ゲットしたコイン数
    /// </summary>
    public int GetSetCoin
    {
        get { return get_coin; }
        set { get_coin = value; }
    }

    /// <summary>
    /// １ゲームの破壊率
    /// </summary>
    public float GetSetDestructionRate
    {
        get { return destruction; }
        set { destruction = value; }
    }

    /// <summary>
    /// スキンの番号
    /// </summary>
    public int GetSetAvatarNumber
    {
        get { return avatar_number; }
        set { avatar_number = value; }
    }

    /// <summary>
    /// 現在の所持コイン
    /// </summary>
    public int GetSetPossessionCoin
    {
        get { return possession_coin; }
        set { possession_coin = value; }
    }

    /// <summary>
    /// 振動の切り替え ON = true, OFF = false
    /// </summary>
    public bool GetSetVibrate 
    {
        get { return vibrate_state; }
        set { vibrate_state = value; }
    }

    public SkinData GetSkinData
    {
        get { return skinData; }
    } 

    public void Save()
    {
        skinData.SkinDataSave();

        PlayerPrefs.SetInt("avatar_number", GetSetAvatarNumber);
        PlayerPrefs.SetInt("possession_coin", GetSetPossessionCoin);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        skinData = new SkinData();
        skinData.SkinDataLoad();

        GetSetAvatarNumber = PlayerPrefs.GetInt("avatar_number");
        GetSetPossessionCoin = PlayerPrefs.GetInt("possession_coin");

        if (GetSetPossessionCoin < 0)
        {
            Debug.LogError("GetSetPossessionCoin=" + GetSetPossessionCoin);
            GetSetPossessionCoin = 0;
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            // バックグラウンドに行ったとき
            Debug.Log("バックグラウンドに行った");
            Save();
        }
        else
        {
            // バックグラウンドから戻ってきたとき
            Debug.Log("バックグラウンドから戻った");
        }
    }

    protected override void Awake()
    {
        base.Awake();

        Load();
    }
}
