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
   //スキン２開放確認
    private bool skine2_open = true;
    //スキン３開放確認
    private bool skine3_open = true;
    //スキン４開放確認
    private bool skine4_open = true;
    //スキン５開放確認
    private bool skine5_open = true;
    //スキン６開放確認
    private bool skine6_open = true;

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

    public bool Skin2_Open
    {
        get { return skine2_open; }
        set { skine3_open = value; }
    }

    public bool Skin3_Open
    {
        get { return skine3_open; }
        set { skine3_open = value; }
    }

    public bool Skin4_Open
    {
        get { return skine4_open; }
        set { skine4_open = value; }
    }

    public bool Skin5_Open
    {
        get { return skine5_open; }
        set { skine5_open = value; }
    }

    public bool Skin6_Open
    {
        get { return skine6_open; }
        set { skine6_open = value; }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("avatar_number", GetSetAvatarNumber);
        PlayerPrefs.SetInt("possession_coin", GetSetPossessionCoin);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        GetSetAvatarNumber = PlayerPrefs.GetInt("avatar_number");
        GetSetPossessionCoin = PlayerPrefs.GetInt("possession_coin");
    }

    protected override void Awake()
    {
        base.Awake();

        Load();
    }
}
