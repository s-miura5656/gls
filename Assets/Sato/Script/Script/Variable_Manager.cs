using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable_Manager : SingletonMonoBehaviour<Variable_Manager>
{
    // ゲットしたコイン
    private int get_coin = 0;
    // 今回の破壊率
    private float destruction = 0f;
    //スキン番号
    private int avatar_number = 0; //save
    //所持コイン枚数
    private int possession_coin = 0; //save

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
