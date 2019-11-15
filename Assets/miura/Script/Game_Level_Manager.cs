using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プランナー用ゲームレベル調整クラス
/// </summary>
public class Game_Level_Manager : MonoBehaviour
{
    // 参照するオブジェクト
    private GameObject main_camera = null;
    private GameObject player = null;

    // 参照するクラス
    private Player_Level_Manager player_level_manager;
    private Time_Manager time_manager;
    private camera_controller camera_move;
    private player_controller_move player_controller;

    // インスペクターで決める数字
    [SerializeField] private int player_level_max = 0;
    [SerializeField] private float move_powor = 0f;
    [SerializeField] private float game_time_max = 0f;
    [SerializeField] private float level_up_time_plus = 0f;
    [SerializeField] private Vector3 camera_first_pos = new Vector3(0f, 0f, 0f);
    [SerializeField] private Vector3 camera_moving_value = new Vector3(0f, 0f, 0f);

    private void Awake()
    {
        // 各オブジェクトのセットアップ
        main_camera = GameObject.Find("MainCamera");
        player = GameObject.Find("Player1");

        // 各クラスのセットアップ
        player_level_manager = gameObject.GetComponent<Player_Level_Manager>();
        camera_move = main_camera.GetComponent<camera_controller>();
        player_controller = player.GetComponent<player_controller_move>();
        time_manager = gameObject.GetComponent<Time_Manager>();
        
        // それぞれの数値を変化させる処理
        player_level_manager.SetLevelMax(player_level_max);
        camera_move.SetFirstPos(camera_first_pos);
        camera_move.SetLevelUpCameraPos(camera_moving_value);
        player_controller.SetMovePowor(move_powor);
        time_manager.SetGameTime(game_time_max);
        time_manager.SetIncreaseTime(level_up_time_plus);
    }
}
