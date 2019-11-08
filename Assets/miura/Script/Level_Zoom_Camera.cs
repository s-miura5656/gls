using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Zoom_Camera : MonoBehaviour
{
    // プレイヤーのレベルを取得用
    [SerializeField] GameObject game_manager;
    // プレイヤーレベルを管理しているスクリプト
    private Player_Level_Manager script;
    // メインカメラを取得
    private Camera main_cam;
    // ズーム用ステート
    private bool zoom_state = false;
    // プレイヤー
    [SerializeField] private GameObject player;
    // FoVの減衰比率
    private float FoVAttenRate = 5.0f;
    // プレイヤーが移動している時のFoV
    private float move_fov;
    // プレイヤーが立ち止まっている時のFoV
    private float stop_fov;
    // Fovリープ減衰用の変数
    private float fov;
    // 前フレームのターゲットの位置
    private Vector3 prevTargetPos;
    // 止まっている時に一定距離離れる為の変数
    private float fov_dist = 50f;
    // レベルごとのfovのベース
    private float fov_base = 60;
    // レベルごとのfov
    private float[] fov_level = new float[10];

    private int old_player_level;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < fov_level.Length; i++)
        {
            fov_level[i] = fov_base + (10 * i);
        }

        script = game_manager.GetComponent<Player_Level_Manager>();

        main_cam = gameObject.GetComponent<Camera>();

        prevTargetPos = player.transform.position;

        old_player_level = script.GetLevel();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        // スピードが０になったらレベルに合わせてカメラの被写界深度変更
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

        //FovTransform();
    }

    private void ZoomCamera() 
    {
        if (script.GetLevel() <= 10)
        {
            main_cam.transform.position += new Vector3(0f, 15f, 15f);
        }
        //main_cam.fieldOfView = fov_level[script.GetLevel() - 1];
        //move_fov = fov_level[script.GetLevel() - 1];
        //stop_fov = move_fov + fov_dist;
        //transform.LookAt(player.transform);
    }

    /// <summary>
    /// Fov変動
    /// </summary>
    private void FovTransform() 
    {
        if (player.transform.position != prevTargetPos)
        {
            fov = move_fov;
        }
        else
        {
            fov = stop_fov;
        }

        main_cam.fieldOfView = Mathf.Lerp(main_cam.fieldOfView, fov, Time.deltaTime * FoVAttenRate);

        prevTargetPos = player.transform.position;
    }
}
