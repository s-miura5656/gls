using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin_double_move : MonoBehaviour
{
    //リワードボタンのサイズ
    [SerializeField]
    private RectTransform coin_double_reword_rect = null;
    [SerializeField]
    private RectTransform coin_double_text_rect = null;

    void Start()
    {
        // DoTweenのシーケンス作成。
        Sequence seq = DOTween.Sequence();
        // シーケンスの繰り返す回数をセット、-1で無限ループ
        seq.SetLoops(-1);
        // シーケンスに拡大処理を追加。
        seq.Append(coin_double_reword_rect.DOScale(new Vector3(1.08f, 1.08f, 1.08f), 1.5f));
        // シーケンスに拡縮処理を追加。
        seq.Append(coin_double_reword_rect.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 1.3f));

        // DoTweenのシーケンス作成。
        Sequence seq2 = DOTween.Sequence();
        // シーケンスの繰り返す回数をセット、-1で無限ループ
        seq2.SetLoops(-1);
        // シーケンスに拡大処理を追加。
        seq2.Append(coin_double_text_rect.DOScale(new Vector3(1.08f, 1.08f, 1.08f), 1.5f));
        // シーケンスに拡縮処理を追加。
        seq2.Append(coin_double_text_rect.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 1.3f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
