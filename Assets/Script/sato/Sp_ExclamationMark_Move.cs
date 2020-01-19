using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Sp_ExclamationMark_Move : MonoBehaviour
{
    [SerializeField]
    RectTransform Sp_Exclamation_Mark;
    ////所持コインの枚数
    private int coin = 0;
    //スキンを全て開いたかの確認
    private int all_open = 0;
    private int move_coin = 10000;


    // Start is called before the first frame update
    void Start()
    {

        Sp_Exclamation_Mark.gameObject.SetActive(false);
        coin = Variable_Manager.Instance.GetSetPossessionCoin;


        Sp_Exclamation_Mark.gameObject.SetActive(true);

        // DoTweenのシーケンス作成。
        Sequence seq = DOTween.Sequence();
        // シーケンスの繰り返す回数をセット、-1で無限ループ
        seq.SetLoops(-1);
        // シーケンスに拡大処理を追加。
        seq.Append(Sp_Exclamation_Mark.DOScale(new Vector3(2, 2, 2), 1.0f));
        // シーケンスに拡縮処理を追加。
        seq.Append(Sp_Exclamation_Mark.DOScale(new Vector3(1, 1, 1), 1.0f));

    }

    void Update()
    {

        coin = Variable_Manager.Instance.GetSetPossessionCoin;

        all_open = Variable_Manager.Instance.Sp_Skin_All;

        if (all_open == 1)
        {
            Sp_Exclamation_Mark.gameObject.SetActive(false);
        }

        if (all_open == 0)
        {
            if (coin >= move_coin)
            {
                Sp_Exclamation_Mark.gameObject.SetActive(true);
            }

            else
                Sp_Exclamation_Mark.gameObject.SetActive(false);

           // coin = Variable_Manager.Instance.GetSetPossessionCoin;
        }
    }


    public void Mark_On()
    {
        if (Variable_Manager.Instance.Sp_Skin_All == 1)
        {
            gameObject.SetActive(false);
        }

        if (Variable_Manager.Instance.GetSetPossessionCoin >= move_coin)
        {
            gameObject.SetActive(true);
        }

    }

    public void Mark_Off()
    {
        gameObject.SetActive(false);
    }

}
