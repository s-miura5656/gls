using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Total_Bar : SingletonMonoBehaviour<Total_Bar>
{

    private float total_rate = 0;  //累計破壊率

    private int rank_now = 0; //現在のランク 
                              //    [SerializeField]
    public Image bronze_rank;
    //    [SerializeField]
    public Image silver_rank;
    //    [SerializeField]
    public Image gold_rank;
    [SerializeField]
    private int[] rank_up;
    [SerializeField]
    private float bar = 0;
    [SerializeField]
    private Image bar_image; // バー
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private RectTransform bronze_rank_pos;
    [SerializeField]
    private RectTransform silver_rank_pos;
    [SerializeField]
    private RectTransform gold_rank_pos;

    private float total;

    void Start()
    {
        total_rate = Variable_Manager.Instance.GetSetTotal_CrashRate;
        //total_rate = 100;
        rank_now = Variable_Manager.Instance.GetSetRank;
        //rank_now = 1;
        Bar_Now();
    }

    void Update()
    {
        //rank_now = 3;
        if (rank_now == 1)
        {
            bronze_rank.gameObject.SetActive(true);
            silver_rank.gameObject.SetActive(false);
            gold_rank.gameObject.SetActive(false);
        }

        else if (rank_now == 2)
        {
            bronze_rank.gameObject.SetActive(false);
            silver_rank.gameObject.SetActive(true);
            gold_rank.gameObject.SetActive(false);
        }

        else if (rank_now == 3)
        {
            bronze_rank.gameObject.SetActive(false);
            silver_rank.gameObject.SetActive(false);
            gold_rank.gameObject.SetActive(true);
        }
    }

    private void Bar_Now()
    {

        total = total_rate >= rank_up[rank_now] ? 100 : total_rate / rank_up[rank_now] * 100;


        bar_image.fillAmount = total / 100.0f;
    }
}
