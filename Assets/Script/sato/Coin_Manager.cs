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
    [SerializeField]
    private GameObject goal;

    private int time = 0;

    [SerializeField]
    private GameObject star;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Transform star_pos;




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

    private bool score_count = false;

    [SerializeField]
    private Text bouns_text;

    public float bouns;

    [SerializeField]
    private Text total_text;
    [SerializeField]
    private Image total_bar;
    [SerializeField]
    private Image total_rate_display;
    private int rank_now = 0;
    [SerializeField]
    private Image bronze_rank;
    [SerializeField]
    private Image silver_rank;
    [SerializeField]
    private Image gold_rank;

    private int total_rate = 0;
    private int get_rate = 0;


    private bool score_up = true;

    private float stage_crash = 0;
    private float play_stage_number = 0;
    private float stage1_rate = 0;
    private float stage2_rate = 0;
    private float stage3_rate = 0;

    void Start()
    {

        //獲得したコイン枚数
        coin_score = Variable_Manager.Instance.GetSetCoin;

        //coin_score = 1000;
        //破壊率
        crash_score_rate = Variable_Manager.Instance.GetSetDestructionRate;
        crash_score_rate = 100;

        coin_score_text = crash_score.GetComponent<Text>();
        coin_score_text.text = coin_score.ToString();
        CrashRate_Get();

        bouns_text.text = bouns.ToString();


        stage_crash = Variable_Manager.Instance.GetSetDestructionRate;
        play_stage_number = Variable_Manager.Instance.Serect_Stage + 1;

        if(play_stage_number == 1)
        {
            stage1_rate = stage_crash;
            UnityAnaltics.Instance.Stage1_Crash(stage1_rate);
        }

        if (play_stage_number == 2)
        {
            stage2_rate = stage_crash;
            UnityAnaltics.Instance.Stage2_Crash(stage2_rate);
        }

        if (play_stage_number == 3)
        {
            stage3_rate = stage_crash;
            UnityAnaltics.Instance.Stage3_Crash(stage3_rate);
        }

        rank_now = 0;
        get_rate = 100;
        // InvokeRepeating("Star_Generate",2f,1f);
        StartCoroutine("StarGenerate");
    }

    // Update is called once per frame
    void Update()
    {
       

        if (score_up == true)
            {
                Variable_Manager.Instance.GetSetPossessionCoin += (int)bonus_score;
                Coin_move();
                score_up = false;
            }
        

        total_text.text = " " + score;

        //if (score_count == true)
        //{

        //    CrashRate_Get();
        //}
        TotalBar_Move();
    }

    public void Coinget_Manager()
    {
        //score = 0;
        //// 数値の変更
        //DOTween.To(
        //    () => score,          // 何を対象にするのか
        //    num => score = num,   // 値の更新
        //    coin_score,                  // 最終的な値
        //    2.0f                  // アニメーション時間
        //).SetEase(Ease.OutCubic);


        //score_count = true;

        
    }

   



    public void CrashRate_Get()
    {
        if (crash_score_rate >= 100)
        {
            bonus_score = coin_score * 2.0f;
            bouns = 2.0f;
            //Coin_move();
        }
        else if (crash_score_rate >= 90)
        {
            bonus_score = coin_score * 1.9f;
            bouns = 1.9f;
            // Coin_move();
        }
        else if (crash_score_rate >= 80)
        {
            bonus_score = coin_score * 1.8f;
            bouns = 1.8f;
            // Coin_move();
        }
        else if (crash_score_rate >= 70)
        {
            bonus_score = coin_score * 1.7f;
            bouns = 1.7f;
            //  Coin_move();
        }
        else if (crash_score_rate >= 60)
        {
            bonus_score = coin_score * 1.6f;
            bouns = 1.6f;
            // Coin_move();
        }
        else if (crash_score_rate >= 50)
        {
            bonus_score = coin_score * 1.5f;
            bouns = 1.5f;
            // Coin_move();
        }
        else if (crash_score_rate >= 40)
        {
            bonus_score = coin_score * 1.4f;
            bouns = 1.4f;
            // Coin_move();
        }
        else if (crash_score_rate >= 30)
        {
            bonus_score = coin_score * 1.3f;
            bouns = 1.3f;
            // Coin_move();
        }
        else if (crash_score_rate >= 20)
        {
            bonus_score = coin_score * 1.2f;
            bouns = 1.2f;
            //  Coin_move();
        }
        else if (crash_score_rate >= 10)
        {
            bonus_score = coin_score * 1.1f;
            bouns = 1.1f;
            // Coin_move();
        }
        else
        {
            bonus_score = coin_score * 1.0f;
            bouns = 1.0f;
            // Coin_move();
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
    }


    public void Calculation_Manager()
    {
        after_score = (int)bonus_score * 2;
        AftterGet_Manager();
        // CrashRate_Get();
    }

    public void AftterGet_Manager()
    {
        //   before_score = before_score;
        // 数値の変更
        DOTween.To(
            () => score,          // 何を対象にするのか
            num => score = num,   // 値の更新
            after_score,          // 最終的な値
            0.5f                  // アニメーション時間
        ).SetEase(Ease.OutCubic);

        total_text.text = "" + score;
    }

    //private void FixedUpdate()
    //{
    //    time++;
    //    if (time > 60)
    //    {
    //        Coin_move();
    //        total_text.text = "" + score;
    //    }
    //}

    public void test_botton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title_ 1");
    }

    private void TotalBar_Move()
    {

       if(get_rate >= 100)
        {

            rank_now++;
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

            get_rate -= 100;
            DOTween.To(
                () =>  get_rate,          // 何を対象にするのか
                num => get_rate = num,   // 値の更新
                100,                  // 最終的な値
                5.0f                  // アニメーション時間
            ).SetEase(Ease.OutCubic);
        }

        total_rate_display.fillAmount = get_rate /100.0f;




        score = 0;
        // 数値の変更




    }


    IEnumerator StarGenerate()
    {
        int _starNum = ((int)crash_score_rate) / 2;

        for (int i = 0; i < _starNum; i++)
        {
           
            GameObject _star = Instantiate(star, star_pos.transform.position, Quaternion.identity);

            _star.transform.parent = canvas.transform;
            _star.transform.position = star_pos.position;
            _star.transform.localScale = Vector3.one;
            _star.GetComponent<Star_Move>().Goal_Set(goal);
            

            yield return new WaitForSeconds(0.1f);

        }

        
    }

}


