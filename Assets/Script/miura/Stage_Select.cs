using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class Stage_Select : MonoBehaviour
{
    private float close_anime_time = 0.3f;
    
    public void StageSelect(int number)
    {
        SceneManager.LoadScene("GameMain_" + number);
        UnityAnaltics.Instance.Stage_Serect(number);
        UnityAnaltics.Instance.Skin_now(Variable_Manager.Instance.GetSetAvatarNumber);
        Variable_Manager.Instance.Serect_Stage = number;
    }

    public void CloseStageSelect()
    {
        Sequence seq = DOTween.Sequence();

        // アニメーション追加
        seq.Append(gameObject.transform.DOScaleY(0.0f, close_anime_time));

        seq.OnStart(() => {
            // アニメーション開始時によばれる
            Debug.Log("Animation Start");
        });

        seq.OnUpdate(() => {
            // 対象の値が変更される度によばれる
            Debug.Log("Animation Update");
        });

        seq.OnComplete(() => {
            Debug.Log("Animation End");
            seq.Complete();
            // アニメーションが終了時によばれる
        });
        

    }
}
