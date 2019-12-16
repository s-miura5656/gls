using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    // プレイヤーパラメーターの取得
    [SerializeField] private PlayerParametor player_parametor_script = null;
    // データマネージャーの取得
    [SerializeField] private Game_Level_Manager game_level_script = null;
    // プレイヤーとカメラ間のオフセット距離
    private Vector3 offset = new Vector3(0f, 0f, 0f);
    // カメラの位置
    private Vector3 camera_base_pos = new Vector3(0f, 0f, 0f);
    private Vector3 camera_move_pos = new Vector3(0f, 0f, 0f);
    // ラープ補完用カメラの移動速度
    private float camera_speed = 0.6f;
    // カメラの初期位置
    private Vector3 first_pos = new Vector3(0f, 60f, -50f);

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = game_level_script.GetPlayer().transform.position + first_pos;

        // プレイヤーとカメラ間の距離を取得してそのオフセット値を計算し、格納します。
        offset = transform.position - game_level_script.GetPlayer().transform.position;
    }
    
    void FixedUpdate()
    {
        // Lerp補完用の始点の記憶
        camera_base_pos = transform.position;

        MoveCamera();

        // プレイヤーを中心に捉える
        transform.LookAt(game_level_script.GetPlayer().transform.position);
    }   

    /// <summary>
    /// カメラの移動
    /// </summary>
    private void MoveCamera()
    {
        // カメラの transform.yの位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
        camera_move_pos = game_level_script.GetPlayer().transform.position + offset;

        // Lerp補完で滑らか移動
        gameObject.transform.position = Vector3.Lerp(camera_base_pos, camera_move_pos, camera_speed);
    }

    /// <summary>
    /// レベルアップ時のカメラのズーム
    /// </summary>
    public void ZoomCamera(int player_level)
    {
        var newPos = gameObject.transform.position + player_parametor_script.PlayerLevelUpCamera[player_level - 1];
        var offSet = newPos - game_level_script.GetPlayer().transform.position;

        DOTween.To(
            () => offset,          // 何を対象にするのか
            num => offset = num,   // 値の更新
            offSet,                // 最終的な値
            0.5f                   // アニメーション時間
        ).SetEase(Ease.OutCubic);
    }

    /// <summary>
    /// 初期位置
    /// </summary>
    /// <param name="pos">プレイヤーの位置にプラスする</param>
    public void SetFirstPos(Vector3 pos)
    {
        first_pos = pos;
    }
}
