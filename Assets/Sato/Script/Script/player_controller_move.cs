﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_controller_move : MonoBehaviour
{
    // プレイヤーのリジッドボディ
    private Rigidbody rb;
    // 引っ張りの始点
    private Vector3 start_pos;
    // 引っ張って離したときの点
    private Vector3 end_pos;
    // 離したときにプレイヤーにかける力
    private Vector3 start_direction;
    // 離したときにプレイヤーにかける力に追加する値
    private float powor;
    // 最初にタップした位置から動かして離すまでの距離
    private float dist;
    // distに割ってspeedを出すための変数
    private float powor_up = 20f;
    // プレイヤーの速度
    private float speed;
    // ゲームマネージャーオブジェクトの取得
    [SerializeField] private GameObject game_manager;
    // ゲーム開始の時間を管理しているスクリプト
    private Time_Manager time_script;
    // プレイヤーを回転させるためのコライダー
    private SphereCollider sphere_collider;
    // プレイヤーのレベルを管理するスクリプト
    private Player_Level_Manager player_level_manager_script;
    // プレイヤーのレベルが上がっていくにつれて加える力
    private float[] player_powor = new float[10];


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphere_collider = gameObject.GetComponent<SphereCollider>();
        time_script = game_manager.GetComponent<Time_Manager>();
        player_level_manager_script = game_manager.GetComponent<Player_Level_Manager>();

        player_powor[0] = 0.8f;
        player_powor[1] = 1.2f;
        player_powor[2] = 1.5f;
        player_powor[3] = 1.7f;
        player_powor[4] = 1.7f;
        player_powor[5] = 1.7f;
        player_powor[6] = 1.7f;
        player_powor[7] = 1.7f;
        player_powor[8] = 1.7f;
        player_powor[9] = 1.7f;
    }

    void Update()
    {
        PullController();

        SpeedDown();
    }

    private void FixedUpdate()
    {
        FowardRotation();
    }

    /// <summary>
    /// 進行方向へ回転させる
    /// </summary>
    private void FowardRotation() 
    {
        // 位置の変化量
        var translation = rb.velocity * Time.deltaTime;

        // 移動した距離
        var distance = translation.magnitude;

        // ワールド空間でのスケール推定値
        var scaleXYZ = transform.lossyScale;

        // 各軸のうち最大のスケール
        var scale = Mathf.Max(scaleXYZ.x, scaleXYZ.y, scaleXYZ.z);

        // 球が回転するべき量
        var angle = distance / (sphere_collider.radius * scale);

        // 球が回転するべき軸
        var axis = Vector3.Cross(Vector3.up, translation).normalized;

        // 現在の回転に加えるべき回転
        var deltaRotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, axis); 

        // 現在の回転からさらにdeltaRotationだけ回転させる
        rb.MoveRotation(deltaRotation * rb.rotation);
    }

    /// <summary>
    /// 引っ張り操作
    /// </summary>
    private void PullController() 
    {
        // マウスの動きと反対方向に発射される
        if (Input.GetMouseButtonDown(0))
        {
            // プレイヤーにかかっている力をゼロにする
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // プレイヤーを遅くする（バレットタイム）
            //this.rb.velocity = Vector3.Normalize(this.rb.velocity) * 3.0f;

            // マウスのボタンを押した場所（始点）
            this.start_pos = Input.mousePosition;
            // プレイヤーにかける力の変数を０に戻す
            start_direction *= 0;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            // マウスのボタンを離した場所（終点）
            end_pos = Input.mousePosition;

            // 引っ張った時の始点から離すまでの移動距離
            dist = (start_pos - end_pos).magnitude;

            // 引っ張り上限
            if (dist >= 200.0f)
            {
                dist = 200.0f;
            }
            // 引っ張り下限
            if (dist <= 30.0f)
            {
                dist = 30.0f;
            }

            // 引っ張りに応じて力を加える
            powor = dist / powor_up;

            // 引っ張りに応じた力にプレイヤーのレベルを追加
            powor = powor * player_powor[player_level_manager_script.GetLevel() - 1];

            // 引っ張った方向とは逆方向のベクトル
            start_direction = -1 * (end_pos - start_pos).normalized;

            // カウントダウン後動けるようになる
            if (time_script.GetGamePlayState())
            {
                rb.AddForce(new Vector3(start_direction.x * powor, 0.0f, start_direction.y * powor), ForceMode.Impulse);
            }
        }
    }

    /// <summary>
    /// 減速と停止
    /// </summary>
    private void SpeedDown()
    {
        // プレイヤーの速度の計算
        speed = rb.velocity.magnitude;

        // 一定速度以下になった時にプレイヤーを停止させる
        if (speed <= 5f)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    /// <summary>
    /// プレイヤーの速度を変える
    /// </summary>
    /// <param name="powor"></param>
    public void SetMovePowor(float powor) 
    {
       powor_up = powor;
    }

    private void Reset()
    {
        game_manager = GameObject.Find("GameManager");
    }
}
