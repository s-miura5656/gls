using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TeruTeru/Create GameLevelData", fileName = "GameLevelData")]
public class GameLevelData : ScriptableObject
{
    [Header("プレイヤーのレベルの最大値")] public int player_level_max = 0;
    [Header("移動させる速度")] public float move_powor = 0f;
    [Header("ゲーム時間")] public float game_time_max = 0f;
    [Header("レベルアップ時に増える時間")] public float level_up_time_plus = 0f;
    [Header("プレイヤーの初期サイズ")] public float player_scale = 1f;
    [Header("カメラの初期位置（プレイヤー起点）")] public Vector3 camera_first_pos = new Vector3(0f, 0f, 0f);
    [Header("レベルアップ時にカメラを離す距離")] public Vector3 camera_moving_value = new Vector3(0f, 0f, 0f);
    [Header("１レベル時のコインの出る数")] public int coin_number = 3;
}
