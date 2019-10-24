using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    // プレイヤーのゲームオブジェクト
    [SerializeField] private GameObject player;
    // プレイヤーとカメラ間のオフセット距離
    private Vector3 offset;
    // カメラの位置
    private Vector3 camera_base_pos;
    private Vector3 camera_move_pos;
    [SerializeField] private float camera_speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーとカメラ間の距離を取得してそのオフセット値を計算し、格納します。
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 各フレームで、Update の後に LateUpdate が呼び出されます。
    void LateUpdate()
    {
        camera_base_pos = transform.position;

        // カメラの transform.yの位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
        camera_move_pos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) + new Vector3(offset.x, 0f, offset.z);

        transform.position = Vector3.Lerp(camera_base_pos, camera_move_pos, camera_speed);
        //transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 3);
    }
}
