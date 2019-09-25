using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Move : MonoBehaviour
{
    // 弾が出た瞬間の位置
    private Vector3 base_pos;
    // 移動距離
    private float moving_distance;
    // １フレーム当たりの移動量
    private float move_bullet_z;
    private float move_bullet_x;
    // 移動量
    private float dis;
    // Start is called before the first frame update
    void Start()
    {
        base_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(base_pos, transform.position);

        // 弾の移動処理
        //transform.position += new Vector3(move_bullet_x, 0f, move_bullet_z);
        transform.position += new Vector3(move_bullet_x, move_bullet_z, 0f);
        DestroyBullet();
    }

    /// <summary>
    /// 一定距離進んだら消える
    /// </summary>
    private void DestroyBullet()
    {
        if (dis >= moving_distance)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 進む距離を入れる
    /// </summary>
    public void MovingDistance(float number, float move_z, float move_x)
    {
        moving_distance = number;
        move_bullet_x = move_x;
        //move_bullet_z = move_z;
        move_bullet_z = move_z;
    }
}
