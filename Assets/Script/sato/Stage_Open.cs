using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage_Open : MonoBehaviour
{
    [SerializeField]
    private Image stage_block;

    private int rank = 0;

    void Start()
    {
        stage_block.gameObject.SetActive(false);
        rank = Variable_Manager.Instance.GetSetRank;

        if (rank >= 2)
        {
        stage_block.gameObject.SetActive(true);
        }
    }


    void Update()
    {
        
    }
}
