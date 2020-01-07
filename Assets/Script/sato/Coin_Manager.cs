using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Coin_Manager : MonoBehaviour
{
    private int silver_now = 0;
    private int gold_now = 0;

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
    private int rank_now = 1;
    [SerializeField]
    private Image bronze_rank;
    [SerializeField]
    private Image silver_rank;
    [SerializeField]
    private Image gold_rank;
    [SerializeField]
    private int[] rank_up;

    // トータル破壊率
    private float total_rate = 0;
    // 獲得破壊率
    private float get_rate = 0;


    private bool score_up = true;

    private float stage_crash = 0;
    private float play_stage_number = 0;
    private float stage1_rate = 0;
    private float stage2_rate = 0;
    private float stage3_rate = 0;

    private Sequence bar_seq;

    public GameObject[] bars = new GameObject[3];

    [SerializeField]
    private GameObject stage_open;
    [SerializeField]
    private Image silver_up;
    [SerializeField]
    private Image gold_up;
    private float display_time = 0;
    private float pos_y;
    private bool silver_on = false;
    private bool gold_on = false;

    //シルバーランクに上がったかの確認
    private int rank_up_silver = 0;
    //ゴールドランクに上がったかの確認
    private int rank_up_gold = 0;

    void Start()
    {
        total_rate_display.fillAmount = 1f;
        total_rate = Variable_Manager.Instance.GetSetTotal_CrashRate;
        rank_now = Variable_Manager.Instance.GetSetRank;




        bars[0] = GameObject.Find("bronze_rank_image");
        bars[1] = GameObject.Find("silver_rank_image");
        bars[2] = GameObject.Find("gold_rank_image");


        if (rank_now == 1)
        {
            bars[0].gameObject.SetActive(true);
            bars[1].gameObject.SetActive(false);
            bars[2].gameObject.SetActive(false);
        }

        if (rank_now == 2)
        {
            bars[0].gameObject.SetActive(false);
            bars[1].gameObject.SetActive(true);
            bars[2].gameObject.SetActive(false);
        }

        if (rank_now == 3)
        {
            bars[0].gameObject.SetActive(false);
            bars[1].gameObject.SetActive(false);
            bars[2].gameObject.SetActive(true);
        }

        bar_seq = DOTween.Sequence();

        //獲得したコイン枚数 
        coin_score = Variable_Manager.Instance.GetSetCoin;
        //coin_score = 1000;



        //破壊率


        crash_score_rate = Variable_Manager.Instance.GetSetDestructionRate;
        Variable_Manager.Instance.GetSetTotal_CrashRate += crash_score_rate;
        //crash_score_rate = 30f;
        coin_score_text = crash_score.GetComponent<Text>();
        coin_score_text.text = coin_score.ToString();
        CrashRate_Get();

        reword_total.text = "×" + (int)bonus_score * 2;

        bouns_text.text = bouns.ToString();


        // stage_crash = Variable_Manager.Instance.GetSetDestructionRate;
        play_stage_number = Variable_Manager.Instance.Serect_Stage;

        if (play_stage_number == 1)
        {
            stage1_rate = crash_score_rate;
            UnityAnaltics.Instance.Stage1_Crash(stage1_rate);
        }

        if (play_stage_number == 2)
        {
            stage2_rate = crash_score_rate;
            UnityAnaltics.Instance.Stage2_Crash(stage2_rate);
        }

        if (play_stage_number == 3)
        {
            stage3_rate = crash_score_rate;
            UnityAnaltics.Instance.Stage3_Crash(stage3_rate);
        }

        //rank_now = 1;
        InvokeRepeating("Star_Generate", 2f, 1f);

        //total_rate = 20;// Variable_Manager.Instance.GetSetTotal_CrashRate;
        total_rate_display.fillAmount = total_rate / rank_up[rank_now];
        get_rate = total_rate_display.fillAmount * 100;
        //total_rate += 50;// crash_score_rate;
        total_rate += crash_score_rate;


        if (total_rate >= rank_up[rank_now])
        {
            bar_seq.Append(DOTween.To(
                            () => get_rate,          // 何を対象にするのか
                            num => get_rate = num,   // 値の更新
                            100,                  // 最終的な値
                            2.0f                  // アニメーション時間
                        )).SetEase(Ease.OutCubic);
        }

        else
        {
            bar_seq.Append(DOTween.To(
                              () => get_rate,          // 何を対象にするのか
                              num => get_rate = num,   // 値の更新
                              total_rate / rank_up[rank_now] * 100,                 // 最終的な値
                              2.0f                  // アニメーション時間
                          )).SetEase(Ease.OutCubic);
        }

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
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title_1");
    }

    private void TotalBar_Move()
    {

        if (get_rate >= 100)
        {
            bar_seq.Complete();

            rank_now++;
            Variable_Manager.Instance.GetSetRank = rank_now;
            //if (rank_now == 1)
            //{
            //    bronze_rank.gameObject.SetActive(true);
            //    silver_rank.gameObject.SetActive(false);
            //    gold_rank.gameObject.SetActive(false);
            //}

            if (rank_now == 2)
            {
                bars[0].SetActive(false);
                bars[1].SetActive(true);
                bars[2].SetActive(false);
                //bronze_rank.gameObject.SetActive(false);
                //silver_rank.gameObject.SetActive(true);
                //gold_rank.gameObject.SetActive(false);
            }

            else if (rank_now == 3)
            {
                bars[0].SetActive(false);
                bars[1].SetActive(false);
                bars[2].SetActive(true);
                //bronze_rank.gameObject.SetActive(false);
                //silver_rank.gameObject.SetActive(false);
                //gold_rank.gameObject.SetActive(true);
            }

            get_rate = 0;
            bar_seq.Append(DOTween.To(
                () => get_rate,          // 何を対象にするのか
                num => get_rate = num,   // 値の更新
                total_rate >= rank_up[rank_now] ? 100 : total_rate / rank_up[rank_now] * 100,                  // 最終的な値
                5.0f                  // アニメーション時間
            )).SetEase(Ease.OutCubic);
        }

        total_rate_display.fillAmount = get_rate / 100.0f;


        rank_up_silver = Variable_Manager.Instance.Silver_Up;
        rank_up_gold = Variable_Manager.Instance.Gold_Up;

        if (rank_now == 2)
        {
            if (rank_up_silver == 0)
            {


                silver_up.gameObject.SetActive(true);
                rank_up_silver = 1;
                Variable_Manager.Instance.Silver_Up = rank_up_silver;

                //if (silver_on == false)
                Invoke("Silver_Rank_up", 3.0f);

                silver_now = 1;
                UnityAnaltics.Instance.Runk_Silver(silver_now);
                silver_now = 0;

            }
        }

        if (rank_now == 3)
        {
            if (rank_up_gold == 0)
            {
                gold_up.gameObject.SetActive(true);
                rank_up_gold = 1;
                Variable_Manager.Instance.Gold_Up = rank_up_gold;

                Invoke("Gold_Rank_up", 2.0f);

                gold_now = 1;
                UnityAnaltics.Instance.Runk_Gold(gold_now);
                gold_now = 0;

            }
        }

    }

    private void Silver_Rank_up()
    {
        stage_open.SetActive(true);
        pos_y = silver_up.rectTransform.rotation.y;

        Sequence seq = DOTween.Sequence();
        // アニメーション追加
        // seq.Append(silver_up.transform.DORotate(new Vector3(0, 90, 0), 1.0f)).SetEase(Ease.InQuad);

        seq.OnStart(() => {
            seq.Append(silver_up.transform.DORotate(new Vector3(0, 90, 0), 1.0f));


            seq.OnComplete(() =>

            stage_open.gameObject.SetActive(false));
            seq.Complete();

        });



        //silver_on = true;
        //rank_up_silver = 1;
        //Variable_Manager.Instance.Silver_Up = rank_up_silver;
    }


    private void Gold_Rank_up()
    {
        Sequence seq = DOTween.Sequence();
        // アニメーション追加
        seq.Append(gold_up.transform.DOScaleY(0.0f, 0.3f));
    }


    private void Rank_UP()
    {


        if (total_rate >= rank_up[2])
        {
            rank_now = 3;
        }


        else if (total_rate >= rank_up[1])
        {
            rank_now = 2;

        }
        else
        {
            rank_now = 1;
        }
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