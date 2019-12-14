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
    [SerializeField] private PlayerParametor player_parametor_script = null;

    // 参照するクラス
    private Bill_Obsever bill_obsever;
    private Time_Manager time_manager;
    private camera_controller camera_move;

    // プレイヤーの初期位置用
    private int pos_number = 0;

    private void Awake()
    {
        // 各クラスのセットアップ
        camera_move = main_camera.GetComponent<camera_controller>();
        time_manager = gameObject.GetComponent<Time_Manager>();
        bill_obsever = city.GetComponent<Bill_Obsever>();

        // それぞれの数値を変化させる処理
        camera_move.SetFirstPos(gameLevelData.CameraFirstPos);
        camera_move.SetLevelUpCameraPos(gameLevelData.CameraMoveValue);
        time_manager.SetGameTime(gameLevelData.GameTimeMax);
        time_manager.SetIncreaseTime(gameLevelData.LevelUpTimePlus);
        bill_obsever.SetCoinNumber(gameLevelData.CoinNumber);

        pos_number = Random.Range(0, player_parametor_script.PlayerFirstPos.Length);

        city.transform.position = player_parametor_script.PlayerFirstPos[pos_number];
        city.transform.rotation = Quaternion.Euler(player_parametor_script.PlayerFirstRotation[pos_number]);
    }

    public GameObject GetPlayer() { return player; }
}
