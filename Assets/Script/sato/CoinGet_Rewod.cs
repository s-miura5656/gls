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
    //所持コインの枚数
    private int coin_now = 0;
    //リワード押した後のコインの枚数
    private int after_coin = 0;
    //ボタンのブロックイメージ
    [SerializeField]
    private Image block_reword;
    //リワードで見たときのコインの枚数
    private int reword_coin_get = 5000;



    void Start()
    {
        block_reword.gameObject.SetActive(false);
        // ShowAdCallbacksにコールバックを設定
        showAdRewardCallbacks.finishCallback += VideoRerwardResult;
        // リザルトボタンを押したらコールバックを呼び出す
        coin_get_reword.onClick.AddListener(() => UnityAdsUtility.Instance.ShowVideoRewardSkin(showAdRewardCallbacks));

        
        // DoTweenのシーケンス作成。
        Sequence seq = DOTween.Sequence();
        // シーケンスの繰り返す回数をセット、-1で無限ループ
        seq.SetLoops(-1);
        // シーケンスに拡大処理を追加。
        seq.Append(coin_get_reword_rect.DOScale(new Vector3(1.08f, 1.08f, 1.08f), 1.5f));
        // シーケンスに拡縮処理を追加。
        seq.Append(coin_get_reword_rect.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 1.3f));
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
        //上昇中にリワードを押させない処理
        block_reword.gameObject.SetActive(true);
        after_coin = Variable_Manager.Instance.GetSetPossessionCoin + reword_coin_get;

        DOTween.To(
       () => Variable_Manager.Instance.GetSetPossessionCoin,          // 何を対象にするのか
       num => Variable_Manager.Instance.GetSetPossessionCoin = num,   // 値の更新
       after_coin,         // 最終的な値
       0.8f                  // アニメーション時間
       )
       .SetEase(Ease.Linear)
       .OnComplete(() => {
        Variable_Manager.Instance.GetSetPossessionCoin = after_coin;
        block_reword.gameObject.SetActive(false);
       });

    }


}
