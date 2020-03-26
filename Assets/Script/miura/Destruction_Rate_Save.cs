using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction_Rate_Save : MonoBehaviour
{
    // ハイスコアを表示するオブジェクト
    [SerializeField] private GameObject hi_score_obj = null;

    [SerializeField]
    private ParticleSystem paper = null;

    // Start is called before the first frame update
    void Awake()
    {
        if (paper == null)
            return;

        paper.gameObject.SetActive(false);

        // 最高破壊率の更新
        if (Variable_Manager.Instance.GetSetDestructionRate > PlayerPrefs.GetFloat($"Stage_{ Variable_Manager.Instance.Serect_Stage }_DestructionRateMax"))
        {
            PlayerPrefs.SetFloat(($"Stage_{ Variable_Manager.Instance.Serect_Stage }_DestructionRateMax"), Variable_Manager.Instance.GetSetDestructionRate);
            hi_score_obj.SetActive(true);
            paper.gameObject.SetActive(true);
        }

#if UNITY_EDITOR
        Debug.Log("ステージ番号" + Variable_Manager.Instance.Serect_Stage);
        Debug.Log("今回の破壊率" + Variable_Manager.Instance.GetSetDestructionRate);
#endif
    }
}
