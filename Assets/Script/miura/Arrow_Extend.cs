﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Extend : MonoBehaviour
{
    // 左クリックしたときにマウスの位置を保存
    private Vector3 base_mouse_pos = Vector3.zero;
    // スプライトレンダラーの取得
    private SpriteRenderer spriteRenderer = null;
    // プレイヤーの取得
    [SerializeField] private GameObject player = null;
    // ゲームマネージャーの取得
    [SerializeField] private GameObject game_manager = null;
    // プレイヤーレベルを管理しているスクリプト
    private Player_Level_Manager player_level_script = null;
    // 左クリックを押した場所と現在動かしている場所の距離
    private float dist = 0f;
    // プレイヤーのサイズ
    private Vector3 player_size = Vector3.one;
    // プレイヤーの周りをまわる矢印のプレイヤーからの距離
    private float arrow_dist = 1f;
    // 時間を管理するスクリプト
    private Time_Manager time_script = null;


    // Start is called before the first frame update
    void Start()
    {
        player_size = player.transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        player_level_script = game_manager.GetComponent<Player_Level_Manager>();
        time_script = game_manager.GetComponent<Time_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!time_script.GetGameEndState)
        {
            ArrowController();
        }
    }

    private void ArrowController() 
    {
        // 左クリックを押したときに矢印を表示する
        if (Input.GetMouseButtonDown(0))
        {
            // マウスの場所を保存（始点）
            base_mouse_pos = Input.mousePosition;

            // 矢印をプレイヤーを中心にして飛ばしたい方向へ移動させる
            transform.position = player.transform.position
                               + (new Vector3(transform.right.x, 0, transform.right.z).normalized
                               * ((player.transform.localScale.y / 2)));

            // 矢印の表示
            spriteRenderer.enabled = true;
        }

        // 左クリックを押したまま動かすと矢印を飛ばしたい方向へ回転しプレイヤーを中心に移動させる
        if (Input.GetMouseButton(0))
        {
            // 始点を中心にしてマウスを動かしている場所に対しての角度
            float angle = Mathf.Atan2(base_mouse_pos.y - Input.mousePosition.y, base_mouse_pos.x - Input.mousePosition.x);

            // 矢印の回転
            transform.rotation = Quaternion.Euler(new Vector3(90f, -(angle * Mathf.Rad2Deg), 0));

            // 左クリックを押した場所と現在動かしている場所の距離の計算
            dist = (base_mouse_pos - Input.mousePosition).magnitude;

            // 引っ張り上限
            if (dist >= 3f)
            {
                dist = 3f;
            }
            
            // 矢印をプレイヤーを中心にして飛ばしたい方向へ移動させる
            transform.position = player.transform.position
                               + (new Vector3(transform.right.x, 0, transform.right.z).normalized
                               * ((player.transform.localScale.y / 2)));

            //// 引っ張りに対して矢印を引き延ばす
            transform.localScale = new Vector3(dist * player_level_script.GetLevel(), dist * player_level_script.GetLevel(), transform.localScale.z);
        }

        // 左クリックを放したときに矢印を消す
        if (Input.GetMouseButtonUp(0))
        {
            spriteRenderer.enabled = false;
        }
    }
}
