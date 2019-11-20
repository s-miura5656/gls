using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bill_Destroy : MonoBehaviour
{
    // ビルのレベル
    private int bill_level = 0;
    // ビルを壊すまでの回数
    private int bill_crash_number = 0;
    // ビルを何回攻撃したか
    private int bill_attack_count = 0;
    private Bill_Obsever bill_Obsever = null;

    public void Initialized(Bill_Obsever obsever)
    {
        bill_Obsever = obsever;
        BillLevelSerch();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;

        // ビルレベルがプレイ屋のレベルより小さいときに
        if (bill_level < bill_Obsever.Player_Level_Manager.GetLevel())
        {
            Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);
            BillDestroy(hitPos, 10);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return;

        // 現在の攻撃回数
        bill_attack_count++;

        // ビルにヒットした時に音を出す
        bill_Obsever.Player_SE_Manager.PlayHitSound();

        // ビルのレベルがプレイヤーと同じか以下の時
        if (bill_level >= bill_Obsever.Player_Level_Manager.GetLevel())
        {
            bill_crash_number = bill_level - bill_Obsever.Player_Level_Manager.GetLevel();

            if (bill_attack_count > bill_crash_number)
            {
                Vector3 hitPos = Vector3.zero;

                foreach (ContactPoint point in collision.contacts)
                {
                    // プレイヤーと当たった場所の座標
                    hitPos = point.point;
                }

                BillDestroy(hitPos, 40);
            }
        }
    }

    private void BillDestroy(Vector3 hitPosition, int vibrate)
    {
        // エフェクト再生
        var player_level = bill_Obsever.Player_Level_Manager.GetLevel();
        bill_Obsever.PlayCrashEffect(bill_level, transform.position);
        bill_Obsever.PlayHitEffect(player_level, hitPosition);

        // 破壊率計算用の関数
        bill_Obsever.Destruction_Rate_Manager.DownNowRate();
        // 経験値ゲット用
        bill_Obsever.Player_Exp_Get.SetExp((int)bill_level);
        // ゲームオブジェクトを非表示にする
        gameObject.SetActive(false);

        // 当たった時のバイブレーション
        Vibration.Vibrate(vibrate);
    }

    private void BillLevelSerch()
    {
        if (transform.tag == "Bill_Level_1")
        {
            bill_level = 0;
        }

        if (transform.tag == "Bill_Level_1")
        {
            bill_level = 1;
        }

        if (transform.tag == "Bill_Level_2")
        {
            bill_level = 2;
        }

        if (transform.tag == "Bill_Level_3")
        {
            bill_level = 3;
        }

        if (transform.tag == "Bill_Level_4")
        {
            bill_level = 4;
        }

        if (transform.tag == "Bill_Level_5")
        {
            bill_level = 5;
        }
    }

    public int GetBillLevel() { return bill_level; }
}
