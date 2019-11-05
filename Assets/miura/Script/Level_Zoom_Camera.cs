﻿using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        script = game_manager.GetComponent<Player_Level_Manager>();
        main_cam = gameObject.GetComponent<Camera>();
        prevTargetPos = player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // スピードが０になったらレベルに合わせてカメラの被写界深度変更
        if (script.GetSpeed() <= 5.0f)
        {
            if (zoom_state == false)
            {
                ZoomCamera();
                zoom_state = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            zoom_state = false;
        }

        FovTransform();
    }

    private void ZoomCamera() 
    {
        if (script.GetLevel() == 1)
        {
            stop_fov = 60f;
            move_fov = stop_fov + 15f;
            //transform.LookAt(player.transform);
        }

        if (script.GetLevel() == 2)
        {
            stop_fov = 70f;
            move_fov = stop_fov + 15f;
            //transform.LookAt(player.transform);
        }

        if (script.GetLevel() == 3)
        {
            stop_fov = 80f;
            move_fov = stop_fov + 15f;
            //transform.LookAt(player.transform);
        }

        if (script.GetLevel() == 4)
        {
            stop_fov = 90f;
            move_fov = stop_fov + 15f;
            //transform.LookAt(player.transform);
        }

        if (script.GetLevel() == 5)
        {
            stop_fov = 100f;
            move_fov = stop_fov + 15f;
            //transform.LookAt(player.transform);
        }
    }

    /// <summary>
    /// Fov変動
    /// </summary>
    private void FovTransform() 
    {
        if (player.transform.position != prevTargetPos)
        {
            fov = stop_fov;
        }
        else
        {
            fov = move_fov;
        }

        main_cam.fieldOfView = Mathf.Lerp(main_cam.fieldOfView, fov, Time.deltaTime * FoVAttenRate);

        prevTargetPos = player.transform.position;
    }
}
