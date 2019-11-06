using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Bullet_Move : MonoBehaviour
{
    // 弾が出た瞬間の位置
    private Vector3 base_pos;
    // 移動距離
    private float moving_distance = 19f;
    // １フレーム当たりの移動量
    private float move_bullet_y;
    private float move_bullet_x;
    // 移動量
    private float dis;
    // 右に行くか左に行くか
    private bool right_or_left;

    private int slow_time;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = true;

        if (right_or_left == true)
        {
            move_bullet_x = 0.1f;
        }
        else
        {
            move_bullet_x = -0.1f;
        }

        base_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(base_pos, transform.position);

        // 弾の移動処理
        //transform.position += new Vector3(move_bullet_x, 0f, move_bullet_z);

        if (Input.GetMouseButton(0))
        {
            transform.position += new Vector3(move_bullet_x / 3.0f, move_bullet_y / 3.0f, 0f);
        }

        else
        {
            transform.position += new Vector3(move_bullet_x, move_bullet_y, 0f);
        }
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
        move_bullet_y = move_z;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wallblock")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "up_floor")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "out_wall")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "player")
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 右か左か
    /// </summary>
    /// <param name="or">右 = true  左 = false</param>
    public void RightOrLeft(bool or)
    {
        right_or_left = or;
    }

}
