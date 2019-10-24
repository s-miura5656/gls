using System.Collections;
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
    private float powor_up = 2f;
    // プレイヤーの速度
    private float speed;
    
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity *= 0.994f;

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

            // 引っ張った方向とは逆方向のベクトル
            start_direction = -1 * (end_pos - start_pos).normalized;

            // プレイヤーに力を加える
            rb.AddForce(new Vector3(start_direction.x * powor, 0f, start_direction.y * powor), ForceMode.Impulse);
        }

        // プレイヤーの速度の計算
        speed = rb.velocity.magnitude;

        // 一定速度以下になった時にプレイヤーを停止させる
        if (speed <= 5f)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        
    }
}
