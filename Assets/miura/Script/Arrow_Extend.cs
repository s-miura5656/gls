using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Extend : MonoBehaviour
{
    // 左クリックしたときにマウスの位置を保存
    private Vector3 base_mouse_pos;
    // スプライトレンダラーの取得
    private SpriteRenderer spriteRenderer = null;
    // プレイヤーの取得
    [SerializeField] private GameObject player = null;
    // ゲームマネージャーの取得
    [SerializeField] private GameObject game_manager = null;
    // プレイヤーレベルを管理しているスクリプト
    private Player_Level_Manager player_level_script;
    // 左クリックを押した場所と現在動かしている場所の距離
    private float dist;
    // プレイヤーのサイズ
    private Vector3 player_size;
    // プレイヤーの周りをまわる矢印のプレイヤーからの距離
    private float arrow_dist = 2f;
    // Start is called before the first frame update
    void Start()
    {
        player_size = player.transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        player_level_script = game_manager.GetComponent<Player_Level_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリックを押したときに矢印を表示する
        if (Input.GetMouseButtonDown(0))
        {
            // 矢印の表示
            spriteRenderer.enabled = true;
            // マウスの場所を保存（始点）
            base_mouse_pos = Input.mousePosition;
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

            // 移動距離の最大値
            if (dist >= 200.0f)
            {
                dist = 200.0f;
            }
            // 移動距離の下限値
            if (dist <= 30.0f)
            {
                dist = 30.0f;
            }

            // 矢印をプレイヤーを中心にして飛ばしたい方向へ移動させる
            transform.position = player.transform.position
                               + (new Vector3(transform.right.x, 0.0f, transform.right.z).normalized 
                               * (player_size.z + (arrow_dist * (player_level_script.GetLevel() + 2))));

            // 引っ張りに対して矢印を引き延ばす
            transform.localScale = new Vector3(dist / 40, transform.localScale.y, dist / 40);
        }

        // 左クリックを放したときに矢印を消す
        if (Input.GetMouseButtonUp(0))
        {
            spriteRenderer.enabled = false;
        }
    }
}
