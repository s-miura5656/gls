using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_controller_move : MonoBehaviour
{
    // プレイヤーのリジッドボディ
    [SerializeField]private Rigidbody rb = null;
    // 引っ張りの始点
    private Vector3 start_pos = Vector3.zero;
    // 引っ張って離したときの点
    private Vector3 end_pos = Vector3.zero;
    // 離したときにプレイヤーにかける力
    private Vector3 start_direction = Vector3.zero;
    // 離したときにプレイヤーにかける力に追加する値
    private float powor = 0f;
    // プレイヤーの速度
    private float speed = 0f;
    // プレイヤーの速度の下限値
    private float lower_limit_speed = 5f;
    // ゲームマネージャーオブジェクトの取得
    [SerializeField] private GameObject game_manager = null;
    // ゲーム開始の時間を管理しているスクリプト
    [SerializeField] private Time_Manager time_script = null;
    // プレイヤーを回転させるためのコライダー
    [SerializeField] private SphereCollider sphere_collider = null;
    // プレイヤーのレベルを管理するスクリプト
    [SerializeField] private Player_Level_Manager player_level_manager_script = null;
    // プレイヤーのレベルが上がっていくにつれて加える力
    private float[] player_powor;
    // 操作説明のアニメーション
    [SerializeField] private GameObject operation_anime = null;
    // プレイヤーパラメーターの取得
    [SerializeField] private PlayerParametor player_parametor = null;

    void Start()
    {
        player_powor = new float[player_level_manager_script.PlayerLevelMax];

        for (int i = 0; i < player_powor.Length; i++)
        {
            player_powor[i] = player_parametor.PlayerPowor[i];
        }
    }

    void Update()
    {
        PullController();

        SpeedDown();

        if (!time_script.GetGamePlayState)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
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

            // マウスのボタンを押した場所（始点）
            this.start_pos = Input.mousePosition;

            // プレイヤーにかける力の変数を０に戻す
            start_direction *= 0;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            // マウスのボタンを離した場所（終点）
            end_pos = Input.mousePosition;

            // 引っ張りに応じた力にプレイヤーのレベルを追加
            powor = player_parametor.DistFlat * player_powor[player_level_manager_script.GetLevel() - 1];

            // 引っ張った方向とは逆方向のベクトル
            start_direction = -1 * (end_pos - start_pos).normalized;

            // カウントダウン後動けるようになる
            if (time_script.GetGamePlayState)
            {
                if (operation_anime.activeSelf)
                {
                    operation_anime.SetActive(false);
                }

                rb.AddForce(new Vector3(start_direction.x * powor, 0f, start_direction.y * powor), ForceMode.Impulse);
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
        if (speed <= lower_limit_speed)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void Reset()
    {
        game_manager = GameObject.Find("GameManager");
        rb = gameObject.GetComponent<Rigidbody>();
        sphere_collider = gameObject.GetComponent<SphereCollider>();
        time_script = game_manager.GetComponent<Time_Manager>();
        player_level_manager_script = game_manager.GetComponent<Player_Level_Manager>();
    }
}
