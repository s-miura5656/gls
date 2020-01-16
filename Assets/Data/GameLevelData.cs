using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TeruTeru/Create GameLevelData", fileName = "GameLevelData")]
public class GameLevelData : ScriptableObject
{
    [Header("ゲーム時間")] [SerializeField] private float game_time_max = 0f;
    [Header("レベルアップ時に増える時間")] [SerializeField] private float level_up_time_plus = 0f;
    [Header("カメラの初期位置（プレイヤー起点）")] [SerializeField] private Vector3 camera_first_pos = Vector3.zero;
    [Header("１レベル時のコインの出る数")] [SerializeField] private int coin_number = 0;
    [Header("ビルレベル毎の経験値")] [SerializeField] private int[] bill_get_exp;
    [Header("ビルレベル毎のコイン取得数")] [SerializeField] private int[] bill_get_coin;
    [Header("各ステージの目標破壊率")] [SerializeField] private float[] destruction_target;

    public float GameTimeMax
    {
        get { return game_time_max; }
    }

    public float LevelUpTimePlus
    {
        get { return level_up_time_plus; }
    }

    public Vector3 CameraFirstPos
    {
        get { return camera_first_pos; }
    }

    public int CoinNumber 
    {
        get { return coin_number; }
    }

    public int[] BillGetExp
    {
        get { return bill_get_exp; }
    }

    public int[] BillGetCoin
    {
        get { return bill_get_coin; }
    }

    public float[] DestructionTarget 
    {
        get { return destruction_target; }
    }
}
