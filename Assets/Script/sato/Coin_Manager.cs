using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Coin_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject crash_score;
    private GameObject coincount;
    public float coin_score;
    private Text coin_score_text;
    public int score = 0;
    private Variable_Manager coin_script;


    private int time = 0;

    [SerializeField]
    private Text reword_total;


    private GameObject Date_Object;
    [SerializeField]
    private Text Date_text;
    private int before_score;
    public int after_score = 0;
    [SerializeField]
    private GameObject text_date;

    [SerializeField]
    private CrashScore_Manager CrashScore_Manager;
    private float crash_score_rate;
    private int crash_rate;
    public float bonus_score;


    [SerializeField]
    private Text bouns_text;

    public float bouns;

    [SerializeField]
    private Text total_text;
    [SerializeField]
    private Image total_bar;
    [SerializeField]
    private Image total_rate_display;
    private int rank_now = 1;
    [SerializeField]
    private int[] rank_up;

    private bool score_up = true;

    [SerializeField]
    private GameObject stage_open;
    [SerializeField]
    private Image silver_up;
  
    private float pos_y;
    [SerializeField]
    private ParticleSystem paper = null;

    void Start()
    {
        rank_now = Variable_Manager.Instance.GetSetRank;

        //獲得したコイン枚数 
        coin_score = Variable_Manager.Instance.GetSetCoin;


        //破壊率
        crash_score_rate = Variable_Manager.Instance.GetSetDestructionRate;
 
        Variable_Manager.Instance.GetSetTotal_CrashRate += crash_score_rate;
        coin_score_text = crash_score.GetComponent<Text>();
        coin_score_text.text = coin_score.ToString();
        CrashRate_Get();

        reword_total.text = "×" + (int)bonus_score * 2;
        paper.gameObject.SetActive(false);

        if (Variable_Manager.Instance.GetSetDestructionRate == 100f)
        {
            paper.gameObject.SetActive(true);
        }

    }

    void Update()
    {


        if (score_up == true)
        {
            Variable_Manager.Instance.GetSetPossessionCoin += (int)bonus_score;
            Coin_move();
            score_up = false;
        }

        total_text.text = " " + score;

    }


    public void CrashRate_Get()
    {
        if (crash_score_rate >= 100)
        {
            bonus_score = coin_score * 2.0f;
            bouns = 2.0f;       
        }
        else if (crash_score_rate >= 90)
        {
            bonus_score = coin_score * 1.9f;
            bouns = 1.9f;
        }
        else if (crash_score_rate >= 80)
        {
            bonus_score = coin_score * 1.8f;
            bouns = 1.8f;
        }
        else if (crash_score_rate >= 70)
        {
            bonus_score = coin_score * 1.7f;
            bouns = 1.7f;
        }
        else if (crash_score_rate >= 60)
        {
            bonus_score = coin_score * 1.6f;
            bouns = 1.6f;
        }
        else if (crash_score_rate >= 50)
        {
            bonus_score = coin_score * 1.5f;
            bouns = 1.5f;
        }
        else if (crash_score_rate >= 40)
        {
            bonus_score = coin_score * 1.4f;
            bouns = 1.4f;
        }
        else if (crash_score_rate >= 30)
        {
            bonus_score = coin_score * 1.3f;
            bouns = 1.3f;
        }
        else if (crash_score_rate >= 20)
        {
            bonus_score = coin_score * 1.2f;
            bouns = 1.2f;
        }
        else if (crash_score_rate >= 10)
        {
            bonus_score = coin_score * 1.1f;
            bouns = 1.1f;
        }
        else
        {
            bonus_score = coin_score * 1.0f;
            bouns = 1.0f;
        }
    }

    private void Coin_move()
    {
        int cs = (int)Mathf.Floor(bonus_score);

        DOTween.To(
            () => score,          // 何を対象にするのか
            num => score = num,   // 値の更新
            cs,                  // 最終的な値
            0.5f                  // アニメーション時間
        ).SetEase(Ease.Linear);

        

        Silver_Rank_up();
    }


    public void Calculation_Manager()
    {
        after_score = (int)bonus_score * 2;
        AftterGet_Manager();
    }

    public void AftterGet_Manager()
    {
        // 数値の変更
        DOTween.To(
            () => score,          // 何を対象にするのか
            num => score = num,   // 値の更新
            after_score,          // 最終的な値
            0.5f                  // アニメーション時間
        ).SetEase(Ease.OutCubic);

        total_text.text = "" + score;

        
    }

    private void Silver_Rank_up()
    {
        stage_open.SetActive(true);
        pos_y = silver_up.rectTransform.rotation.y;

        Sequence seq = DOTween.Sequence();
        // アニメーション追加
        // seq.Append(silver_up.transform.DORotate(new Vector3(0, 90, 0), 1.0f)).SetEase(Ease.InQuad);
        seq.Append(silver_up.transform.DORotate(new Vector3(0, 90, 0),1.0f));
        seq.OnComplete(() => 
        {
            silver_up.gameObject.SetActive(false);
            seq.Complete();
        });
    }
}