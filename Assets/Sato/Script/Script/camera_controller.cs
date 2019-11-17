using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    // プレイヤーのゲームオブジェクト
    [SerializeField] private GameObject player = null;
    // プレイヤーとカメラ間のオフセット距離
    private Vector3 offset = new Vector3(0f, 0f, 0f);
    // カメラの位置
    private Vector3 camera_base_pos = new Vector3(0f, 0f, 0f);
    private Vector3 camera_move_pos = new Vector3(0f, 0f, 0f);
    // ラープ補完用カメラの移動速度
    [SerializeField] private float camera_speed = 0.7f;
    // プレイヤーのレベルを取得用
    [SerializeField] private GameObject game_manager = null;
    // プレイヤーレベルを管理しているスクリプト
    private Player_Level_Manager script = null;
    // メインカメラを取得
    private Camera main_cam = null;
    // ズーム用ステート
    private bool zoom_state = false;
    // ズーム変更時に必要なレベルアップ前のレベルを記憶する変数
    private int old_player_level = 0;
    // カメラの初期位置
    private Vector3 first_pos = new Vector3(0f, 30f, -30f);
    // レベルが上がるにつれて上がるカメラのZ軸の値
    private Vector3 level_up_camera_pos = new Vector3(0f, 20f, -20f);
    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーとカメラ間の距離を取得してそのオフセット値を計算し、格納します。
        offset = transform.position - player.transform.position;

        script = game_manager.GetComponent<Player_Level_Manager>();

        main_cam = gameObject.GetComponent<Camera>();

        old_player_level = script.GetLevel();

        main_cam.transform.position = player.transform.position + first_pos;
    }

    private void Update()
    {

    }

    void FixedUpdate()
    {
        // Lerp補完用の始点の記憶
        camera_base_pos = transform.position;

        // カメラの transform.yの位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
        camera_move_pos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) + new Vector3(offset.x, 0f, offset.z);

        // Lerp補完で滑らか移動
        transform.position = Vector3.Lerp(camera_base_pos, camera_move_pos, camera_speed);

        // プレイヤーを中心に捉える
        transform.LookAt(player.transform);

        // レベルが上がったらレベルに合わせてカメラの位置変更
        if (script.GetLevel() > old_player_level)
        {
            if (zoom_state == false)
            {
                ZoomCamera();
                old_player_level = script.GetLevel();

                zoom_state = true;
            }
        }

        if (script.GetSpeed() > 0f)
        {
            zoom_state = false;
        }
    }

    private void ZoomCamera()
    {
        main_cam.transform.position += level_up_camera_pos;
        offset = transform.position - player.transform.position;
        old_player_level = script.GetLevel();
    }

    private void Reset()
    {
        game_manager = GameObject.Find("GameManager");

        player = GameObject.Find("Player");
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
}
