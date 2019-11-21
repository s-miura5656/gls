using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable_Manager : SingletonMonoBehaviour<Variable_Manager>
{
    // ゲットしたコイン
    private int get_coin = 0;
    // 今回の破壊率
    private float destruction = 0f;
    // スキンの番号
    private int skin_number = 0;

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
    /// スキン選択
    /// </summary>
    public int GetSetSkinNumber 
    {
        get { return skin_number; }
        set { skin_number = value; }
    }
}
