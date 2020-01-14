using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Monetization;
using DG.Tweening;

public class CoinGet_Rewod : MonoBehaviour
{
    //リワードボタン
    [SerializeField]
    private Button coin_get_reword = null;
    //リワードボタンのサイズ
    [SerializeField]
    private RectTransform coin_get_reword_rect = null;
    //リワードのコールバックの設定
    private ShowAdCallbacks showAdRewardCallbacks = new ShowAdCallbacks();
    private int coin_now = 0;
    private int after_coin = 0;
    //ボタンのブロックイメージ
    [SerializeField]
    private Image block_reword;



    void Start()
    {
        block_reword.gameObject.SetActive(false);
        // ShowAdCallbacksにコールバックを設定
        showAdRewardCallbacks.finishCallback += VideoRerwardResult;
        // リザルトボタンを押したらコールバックを呼び出す
        coin_get_reword.onClick.AddListener(() => UnityAdsUtility.Instance.ShowVideoReward(showAdRewardCallbacks));

        
        // DoTweenのシーケンス作成。
        Sequence seq = DOTween.Sequence();
        // シーケンスの繰り返す回数をセット、-1で無限ループ
        seq.SetLoops(-1);
        // シーケンスに拡大処理を追加。
        seq.Append(coin_get_reword_rect.DOScale(new Vector3(1.28f, 1.28f, 1.28f), 0.7f));
        // シーケンスに拡縮処理を追加。
        seq.Append(coin_get_reword_rect.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1.0f));
    }

    void Update()
    {
      
    }



    private void VideoRerwardResult(ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            //　広告を最後まで視聴した時
            coin_now = Variable_Manager.Instance.GetSetPossessionCoin;
            Coin_Get();
        }
        else if (showResult == ShowResult.Failed)
        {
            // 広告読み込みエラー
        }
        else if (showResult == ShowResult.Skipped)
        {
            // 広告をスキップした時
        }
    }

    private void OnDestroy()
    {
        // ShowAdCallbacksにコールバックを解除
        showAdRewardCallbacks.finishCallback -= VideoRerwardResult;
    }

    private void Coin_Get()
    {
        //上昇中にリワードを押されない処理
        block_reword.gameObject.SetActive(true);
        after_coin = Variable_Manager.Instance.GetSetPossessionCoin + 2500;

        DOTween.To(
       () => Variable_Manager.Instance.GetSetPossessionCoin,          // 何を対象にするのか
       num => Variable_Manager.Instance.GetSetPossessionCoin = num,   // 値の更新
       after_coin,         // 最終的な値
       0.8f                  // アニメーション時間
       )
       .SetEase(Ease.Linear)
       .OnComplete(() => {
        block_reword.gameObject.SetActive(false);;
       });

    }
}
