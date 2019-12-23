using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.LWRP;


public class Bill_Destroy : MonoBehaviour
{
    // ビルのレベル
    private int bill_level = 1;
    // ビルのレベルの最大値
    private int max_bill_level = 6;
    // 経験値用ビルのレベル
    private int exp_bill_level = 0;
    // ビルを壊すまでの回数
    private int bill_crash_number = 0;
    // ビルを何回攻撃したか
    private int bill_attack_count = 0;
    // ビルオブザーバーの取得
    private Bill_Obsever bill_Obsever = null;
    // ビルにレンダラー取得
    private Renderer renderer = null;
    // ダメージ表現用
    private float damege = 0.5f;

    public void Initialized(Bill_Obsever obsever)
    {
        bill_Obsever = obsever;
        BillLevelSerch();
        renderer = gameObject.GetComponent<Renderer>();
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;

        // ビルレベルがプレイヤーのレベルより小さいときに
        if (bill_level < bill_Obsever.Player_Level_Manager.GetLevel())
        {
            Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);
            BillDestroy(10, hitPos);
        }
    }

    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return;

        renderer.material.SetColor("_BaseColor", new Color(1, damege, damege, 1));

        // 現在の攻撃回数
        bill_attack_count++;

        if (damege >= 0f)
        {
            damege -= 0.05f;
        }

        Vector3 hitPos = Vector3.zero;

        foreach (ContactPoint point in collision.contacts)
        {
            // プレイヤーと当たった場所の座標
            hitPos = point.point;
        }

        bill_Obsever.PlayHitRefEffect(bill_Obsever.Player_Level_Manager.GetLevel() ,hitPos);

        // ビルのレベルがプレイヤーと同じか高いときに
        if (bill_level >= bill_Obsever.Player_Level_Manager.GetLevel())
        {
            // ビルのレベルからプレイヤーのレベルを引いてビルを何回で壊せるか決める
            bill_crash_number = bill_level - bill_Obsever.Player_Level_Manager.GetLevel();

            if (bill_attack_count > bill_crash_number)
            {
                BillDestroy(40, hitPos);
            }
        }
    }

    [System.Obsolete]
    private void BillDestroy(int vibrate, Vector3 hit_pos)
    {
        // エフェクト再生
        var player_level = bill_Obsever.Player_Level_Manager.GetLevel();
        bill_Obsever.PlayCrashEffect(exp_bill_level, transform.position, player_level, bill_Obsever.Player_Exp_Get.GetCoin(exp_bill_level));
        bill_Obsever.PlayHitEffect(exp_bill_level, hit_pos);

        // ゲーム時間内だけ破壊率と経験値を追加していく処理
        if (bill_Obsever.Time_Manager.GetGamePlayState)
        {
            // 破壊率計算用の関数
            bill_Obsever.Destruction_Rate_Manager.DownNowRate();
            // 経験値ゲット用
            bill_Obsever.Player_Exp_Get.SetExp(exp_bill_level);
        }

        // ゲームオブジェクトを非表示にする
        gameObject.SetActive(false);

        if (Variable_Manager.Instance.GetSetVibrate)
        {
            // 当たった時のバイブレーション
            Vibration.Vibrate(vibrate);
        }
    }

    /// <summary>
    /// ビルにレベルを割り当てる
    /// </summary>
    private void BillLevelSerch()
    {
        for (int i = 0; i < max_bill_level; i++)
        {
            if (transform.tag == "Bill_Level_" + i)
            {
                bill_level += i * 2;
                exp_bill_level = i;
            }
        }
    }
}
