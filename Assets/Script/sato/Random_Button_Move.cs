using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Random_Button_Move : MonoBehaviour
{

    [SerializeField]
    private GameObject random_button;

    // Start is called before the first frame update
    void Start()
    {

        // DoTweenのシーケンス作成。
        Sequence seq = DOTween.Sequence();
        // シーケンスの繰り返す回数をセット、-1で無限ループ
        seq.SetLoops(-1);
        // シーケンスに拡大処理を追加。
        seq.Append(random_button.transform.DOScale(new Vector3(1.25f, 1.25f, 1.25f), 1.8f));
        // シーケンスに拡縮処理を追加。
        seq.Append(random_button.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1.8f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
