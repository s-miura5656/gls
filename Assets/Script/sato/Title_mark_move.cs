using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Title_mark_move : MonoBehaviour
{
    [SerializeField]
    RectTransform Title_Exclamation_Mark;
    ////所持コインの枚数
    private int coin = 0;
    //spスキンを全て開いたかの確認
    private int sp_all_open = 0;
    private int sp_move_coin = 10000;
    //normalスキンを全て開いたかの確認
    private int all_open = 0;
    private int move_coin = 5000;
    void Start()
    {
        // DoTweenのシーケンス作成。
        Sequence seq = DOTween.Sequence();
        // シーケンスの繰り返す回数をセット、-1で無限ループ
        seq.SetLoops(-1);
        // シーケンスに拡大処理を追加。
        seq.Append(Title_Exclamation_Mark.DOScale(new Vector3(2, 2, 2), 1.0f));
        // シーケンスに拡縮処理を追加。
        seq.Append(Title_Exclamation_Mark.DOScale(new Vector3(1, 1, 1), 1.0f));
    }


    void Update()
    {
        coin = Variable_Manager.Instance.GetSetPossessionCoin;

        all_open = Variable_Manager.Instance.Skin_All;
        sp_all_open = Variable_Manager.Instance.Sp_Skin_All;

        // all_openもしくはsp_all_openが1の場合は表示しない
        if (all_open == 1 && sp_all_open == 1)
        {
            Title_Exclamation_Mark.gameObject.SetActive(false);
        }
        else
        {
            // move_coinがcoin以上もしくはsp_move_coinがcoin以上の時表示する
            if (coin >= move_coin || coin >= sp_move_coin)
            {
                Title_Exclamation_Mark.gameObject.SetActive(true);
            }
            else
            {
                Title_Exclamation_Mark.gameObject.SetActive(false);
            }
        }
    }

}
