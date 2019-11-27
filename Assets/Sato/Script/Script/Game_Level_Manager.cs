using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームレベル調整クラス
/// </summary>
public class Game_Level_Manager : MonoBehaviour
{
    // 参照するオブジェクト
    [SerializeField] private GameObject main_camera = null;
    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject city = null;
    [SerializeField] private GameLevelData gameLevelData = null;
    // 参照するクラス
    private Player_Level_Manager player_level_manager;
    private Bill_Obsever bill_obsever;
    private Time_Manager time_manager;
    private camera_controller camera_move;
    private player_controller_move player_controller;

    private void Awake()
    {
        // 各クラスのセットアップ
        player_level_manager = gameObject.GetComponent<Player_Level_Manager>();
        camera_move = main_camera.GetComponent<camera_controller>();
        player_controller = player.GetComponent<player_controller_move>();
        time_manager = gameObject.GetComponent<Time_Manager>();
        bill_obsever = city.GetComponent<Bill_Obsever>();

        // それぞれの数値を変化させる処理
        player_level_manager.SetLevelMax(gameLevelData.player_level_max);
        player_level_manager.SetPlayerScale(gameLevelData.player_scale);
        camera_move.SetFirstPos(gameLevelData.camera_first_pos);
        camera_move.SetLevelUpCameraPos(gameLevelData.camera_moving_value);
        player_controller.SetMovePowor(gameLevelData.move_powor);
        time_manager.SetGameTime(gameLevelData.game_time_max);
        time_manager.SetIncreaseTime(gameLevelData.level_up_time_plus);
        bill_obsever.SetCoinNumber(gameLevelData.coin_number);
    }

    public GameObject GetPlayer() { return player; }

    public GameObject GetMainCamera() { return main_camera; }


}
