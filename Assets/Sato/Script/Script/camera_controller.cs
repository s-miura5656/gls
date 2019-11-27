using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    // プレイヤーのレベルを取得用
    [SerializeField] private GameObject game_manager = null;
    // プレイヤーレベルを管理しているスクリプト
    private Player_Level_Manager script = null;
    // データマネージャーの取得
    private Game_Level_Manager game_level_script = null;
    // メインカメラを取得
    private Camera main_cam = null;

    // プレイヤーとカメラ間のオフセット距離
    private Vector3 offset = new Vector3(0f, 0f, 0f);
    // カメラの位置
    private Vector3 camera_base_pos = new Vector3(0f, 0f, 0f);
    private Vector3 camera_move_pos = new Vector3(0f, 0f, 0f);
    // ラープ補完用カメラの移動速度
    private float camera_speed = 0.7f;
    // ズーム変更時に必要なレベルアップ前のレベルを記憶する変数
    private int old_player_level = 0;
    // カメラの初期位置
    private Vector3 first_pos = new Vector3(0f, 30f, -30f);
    // レベルが上がるにつれて上がるカメラのZ軸の値
    private Vector3 level_up_camera_pos = new Vector3(0f, 20f, -20f);

    private Vector3 new_camera_pos = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        script = game_manager.GetComponent<Player_Level_Manager>();

        main_cam = gameObject.GetComponent<Camera>();

        game_level_script = game_manager.GetComponent<Game_Level_Manager>();

        // プレイヤーとカメラ間の距離を取得してそのオフセット値を計算し、格納します。
        offset = transform.position - game_level_script.GetPlayer().transform.position;

        old_player_level = script.GetLevel();

        gameObject.transform.position = game_level_script.GetPlayer().transform.position + first_pos;
    }
    
    void FixedUpdate()
    {
        // Lerp補完用の始点の記憶
        camera_base_pos = transform.position;

        MoveCamera();

        // プレイヤーを中心に捉える
        transform.LookAt(game_level_script.GetPlayer().transform.position);

        // レベルが上がったらレベルに合わせてカメラの位置変更
        if (script.GetLevel() > old_player_level)
        {
            ZoomCamera();

            old_player_level = script.GetLevel();
        }
    }    
    private void MoveCamera()
    {
        // カメラの transform.yの位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
        camera_move_pos = new Vector3(game_level_script.GetPlayer().transform.position.x, transform.position.y, game_level_script.GetPlayer().transform.position.z) + new Vector3(offset.x, 0f, offset.z);

        // Lerp補完で滑らか移動
        gameObject.transform.position = Vector3.Lerp(camera_base_pos, camera_move_pos, camera_speed);
    }

    private void ZoomCamera()
    {
        gameObject.transform.position += level_up_camera_pos;
        offset = gameObject.transform.position - game_level_script.GetPlayer().transform.position;
        old_player_level = script.GetLevel();
    }

    /// <summary>
    /// 初期位置
    /// </summary>
    /// <param name="pos">プレイヤーの位置にプラスする</param>
    public void SetFirstPos(Vector3 pos)
    {
        first_pos = pos;
    }

    /// <summary>
    /// レベルアップした時に離れる距離
    /// </summary>
    /// <param name="pos"></param>
    public void SetLevelUpCameraPos(Vector3 pos)
    {
        level_up_camera_pos = pos;
    }

    private void Reset()
    {
        game_manager = GameObject.Find("GameManager");
    }
}
