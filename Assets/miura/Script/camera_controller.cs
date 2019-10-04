using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    [SerializeField]
    private GameObject player;       //プレイヤーゲームオブジェクトへの参照を格納する 変数
    private Vector3 offset;         //プレイヤーとカメラ間のオフセット距離を格納する 変数

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーとカメラ間の距離を取得してそのオフセット値を計算し、格納します。
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.LookAt(player.transform);
    }

    // 各フレームで、Update の後に LateUpdate が呼び出されます。
    void LateUpdate()
    {
        //カメラの transform.yの位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) + new Vector3(offset.x, 0f, offset.z);
    }
}
