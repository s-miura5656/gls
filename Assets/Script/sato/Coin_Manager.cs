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
    private bool clear = false;

    public int reword_coin = 0;

    [SerializeField] private GameObject[] stage_button = { null };
    [SerializeField] private GameLevelData game_level_script = null;
    private bool[] achievement_flag = { false };

    public int play_game_number = 0;

    private int open_stage = 0;
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

        reword_total.text = "×" + (int)coin_score * 2;
       
        


        close.onClick.AddListener(Stage_close);

        stage_open.gameObject.SetActive(false);


        Variable_Manager.Instance.Stage_Now = open_stage;

        if (PlayerPrefs.GetInt($"AchievementRateFlag_{ Variable_Manager.Instance.Serect_Stage }") != 1)
            if (PlayerPrefs.GetFloat($"Stage_{ Variable_Manager.Instance.Serect_Stage }_DestructionRateMax") >= game_level_script.DestructionTarget[Variable_Manager.Instance.Serect_Stage])
            {
                clear = true;

                for (int i = 0; i < 24; i++)
                {
                    open_stage += PlayerPrefs.GetInt($"AchievementRateFlag_{ i }");                   
                }

                UnityAnaltics.Instance.PLay_times_number(open_stage);
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


    private void Coin_move()
    {
        int cs = (int)Mathf.Floor(coin_score);

        DOTween.To(
            () => score,          // 何を対象にするのか
            num => score = num,   // 値の更新
            cs,                  // 最終的な値
            1.0f                  // アニメーション時間
        ).SetEase(Ease.OutCubic)
        .OnComplete(() => {
            if(clear)
            Silver_Rank_up(); 
        });


        
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
    }

    private void Stage_close()
    {
        Sequence seq = DOTween.Sequence();
        // アニメーション追加
        seq.Append(open_image.DOScaleY(0.0f, 0.2f));
    }
}