using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Block : MonoBehaviour
{
    // 時間のカウント
    private float time;
    // 撃つ間隔の変数
    [SerializeField]
    private float shot_time;
    // 弾のオブジェクト
    private GameObject bullet;
    // 弾のコピー
    private GameObject bullet_copy;
    // コピーした弾のスクリプトを取得
    private Bullet_Move bulletmove_script;
    // 弾の進む距離
    [SerializeField]
    private float move_distance;
    // １フレーム当たりの移動量
    [SerializeField]
    private float move_bullet_z;
    [SerializeField]
    private float move_bullet_x;

    // Start is called before the first frame update
    void Start()
    {
        bullet = (GameObject)Resources.Load("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        ShotInterval();  
    }

    /// <summary>
    /// 一定間隔で弾を撃つ
    /// </summary>
    private void ShotInterval()
    {
        time += Time.deltaTime;

        if (time >= shot_time)
        {
            bullet_copy = Instantiate(bullet, transform.position, transform.rotation);
            bulletmove_script = bullet_copy.GetComponent<Bullet_Move>();
            //bulletmove_script.MovingDistance(move_distance, move_bullet_z, move_bullet_x);
            bulletmove_script.MovingDistance(move_distance, move_bullet_z, move_bullet_x);
            time = 0;
        }
    }
}
