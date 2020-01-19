using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Coin_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject coin_total_text;
    private GameObject coincount;
    public int coin_score;
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
    private Transform open_image;
    [SerializeField]
    private Image silver_up;
    [SerializeField]
    private Button close = null;
  
    private float pos_y;
    [SerializeField]
    private ParticleSystem paper = null;

    public int reword_coin = 0;

    [SerializeField] private GameObject[] stage_button = { null };
    [SerializeField] private GameLevelData game_level_script = null;
    private bool[] achievement_flag = { false };

    void Start()
    {
        rank_now = Variable_Manager.Instance.GetSetRank;

        //獲得したコイン枚数 
        coin_score = Variable_Manager.Instance.GetSetCoin;
        //coin_score = 1000;


        //破壊率
        crash_score_rate = Variable_Manager.Instance.GetSetDestructionRate;
        //crash_score_rate = 30f;


        //Variable_Manager.Instance.GetSetTotal_CrashRate += crash_score_rate;
        coin_score_text = coin_total_text.GetComponent<Text>();
        coin_score_text.text = coin_score.ToString();
        CrashRate_Get();

        reword_total.text = "×" + (int)coin_score * 2;
        paper.gameObject.SetActive(false);
        

        if (Variable_Manager.Instance.GetSetDestructionRate == 100f)
        {
            paper.gameObject.SetActive(true);
        }

        close.onClick.AddListener(Stage_close);


        if (PlayerPrefs.GetInt($"AchievementRateFlag_{ Variable_Manager.Instance.Serect_Stage }") != 1)
            if (PlayerPrefs.GetFloat($"Stage_{ Variable_Manager.Instance.Serect_Stage }_DestructionRateMax") >= game_level_script.DestructionTarget[Variable_Manager.Instance.Serect_Stage])
            {
                Silver_Rank_up();
            }
    }

    void Update()
    {


        if (score_up == true)
        {
            Variable_Manager.Instance.GetSetPossessionCoin += coin_score;
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
        int cs = (int)Mathf.Floor(coin_score);

        DOTween.To(
            () => score,          // 何を対象にするのか
            num => score = num,   // 値の更新
            cs,                  // 最終的な値
            0.5f                  // アニメーション時間
        ).SetEase(Ease.Linear);

        

       // Silver_Rank_up();
    }


    public void Calculation_Manager()
    {
        after_score = (int)score * 2;
        AftterGet_Manager();
    }

    public void AftterGet_Manager()
    {
        reword_coin = (int)Mathf.Floor(coin_score) * 2;

        // 数値の変更
        DOTween.To(
            () => score,          // 何を対象にするのか
            num => score = num,   // 値の更新
            reword_coin,          // 最終的な値
            0.5f                  // アニメーション時間
        ).SetEase(Ease.OutCubic);

        total_text.text = "" + score;

        
    }

    private void Silver_Rank_up()
    {

        stage_open.SetActive(true);
        

        //Sequence seq = DOTween.Sequence();
        //// アニメーション追加
        //// seq.Append(silver_up.transform.DORotate(new Vector3(0, 90, 0), 1.0f)).SetEase(Ease.InQuad);
        //seq.Append(stage_open.transform.DORotate(new Vector3(0, 90, 0),1.0f));
        //seq.OnComplete(() => 
        //{
        //    silver_up.gameObject.SetActive(false);
        //    seq.Complete();
        //});
    }

    private void Stage_close()
    {
        //pos_y = stage_open.rectTransform.rotation.y;

        Sequence seq = DOTween.Sequence();
        // アニメーション追加
        seq.Append(open_image.DOScaleY(0.0f, 0.2f));
    }
}