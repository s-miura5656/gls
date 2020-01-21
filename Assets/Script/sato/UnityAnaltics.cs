using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;


public class UnityAnaltics : SingletonMonoBehaviour<UnityAnaltics>
{

    
    [SerializeField]
    private Variable_Manager manager_script;

    private int stage_serect;
    


    void Start()
    {
        //タイトルだけ送るパターン
        //SendAnalytics("clash_late");

        //int 破壊率 = 30;

        //if (破壊率 >= 0 && 破壊率 < 30)
        //{
        //    SendAnalytics("clash", new Dictionary<string, object>
        //    {
        //        { "%", 30 }
        //    });
        //}
        //else if (破壊率 >= 30 && 破壊率 < 70)
        //{
        //    SendAnalytics("clash", new Dictionary<string, object>
        //    {
        //        { "%", 70 }
        //    });
        //}
        //else if (破壊率 >= 70 && 破壊率 < 80)
        //{
        //    SendAnalytics("clash", new Dictionary<string, object>
        //    {
        //        { "%", 80 }
        //    });
        //}
        //else if (破壊率 >= 80 && 破壊率 <= 100)
        //{
        //    SendAnalytics("clash", new Dictionary<string, object>
        //    {
        //        { "%", 100 }
        //    });
        //}

        //タイトルとデータを送るパターン
        //SendAnalytics("gameOver", new Dictionary<string, object>
        //{
        //    { "potions", 5 },
        //    { "coins", 100 }
        //});


    }

    public void SendAnalytics(string title)
    {
        Analytics.CustomEvent(title);
    }

    public void SendAnalytics(string title, Dictionary<string, object> data)
    {
        //Debug.Log(title);
        Analytics.CustomEvent(title, data);
    }

    public void open_number()
    {


        int open_number = Variable_Manager.Instance.GetSetOpenSkin;

        if (open_number == 0)
        {
            SendAnalytics("skin_open", new Dictionary<string, object>
            {
                { "Pieces", 0 }
            });
        }
        else if (open_number == 1)
        {
            SendAnalytics("skin_open", new Dictionary<string, object>
            {
                { "Pieces", 1 }
            });
        }
        else if (open_number == 2)
        {
            SendAnalytics("skin_open", new Dictionary<string, object>
            {
                { "Pieces", 2 }
            });
        }
        else if (open_number == 3)
        {
            SendAnalytics("skin_open", new Dictionary<string, object>
            {
                { "Pieces", 3 }
            });
        }
        else if (open_number == 4)
        {
            SendAnalytics("skin_open", new Dictionary<string, object>
            {
                { "Pieces", 4 }
            });
        }
        else if (open_number == 5)
        {
            SendAnalytics("skin_open", new Dictionary<string, object>
            {
                { "Pieces", 5 }
            });
        }
        else if (open_number == 6)
        {
            SendAnalytics("skin_open", new Dictionary<string, object>
            {
                { "Pieces", 6 }
            });
        }
        else if (open_number == 7)
        {
            SendAnalytics("skin_open", new Dictionary<string, object>
            {
                { "Pieces", 7 }
            });
        }
        else if (open_number == 8)
        {
            SendAnalytics("skin_open", new Dictionary<string, object>
            {
                { "Pieces", 8 }
            });
        }
    }

    public void Play_time()
    {
        float game_time = manager_script.play_time;



        if (game_time >= 0 && game_time < 10)
        {
            SendAnalytics("play_time", new Dictionary<string, object>
            {
                { "sec", 10 }
            });
        }
        else if (game_time >= 10 && game_time < 30)
        {
            SendAnalytics("play_time", new Dictionary<string, object>
            {
                { "sec", 30 }
            });
        }
        else if (game_time >= 30 && game_time < 60)
        {
            SendAnalytics("play_time", new Dictionary<string, object>
            {
                { "sec", 60 }
            });
        }
        else if (game_time >= 60 && game_time < 180)
        {
            SendAnalytics("play_time", new Dictionary<string, object>
            {
                { "sec", 180 }
            });
        }
        else if (game_time >= 180)
        {
            SendAnalytics("play_time", new Dictionary<string, object>
            {
                { "sec", 999 }
            });
        }

    }

    public void Skin_now(int skin_number_now)
    {

        //int skin_number_now = Variable_Manager.Instance.GetSetAvatarNumber;



        if (skin_number_now == 0)
        {
            SendAnalytics("now_number", new Dictionary<string, object>
            {
                { "now", 0 }
            });
        }
        else if (skin_number_now == 1)
        {
            SendAnalytics("play_time", new Dictionary<string, object>
            {
                { "now", 1 }
            });
        }
        else if (skin_number_now == 2)
        {
            SendAnalytics("play_time", new Dictionary<string, object>
            {
                { "now", 2 }
            });
        }
        else if (skin_number_now == 3)
        {
            SendAnalytics("play_time", new Dictionary<string, object>
            {
                { "now", 3 }
            });
        }

        else if (skin_number_now == 4)
        {
            SendAnalytics("play_time", new Dictionary<string, object>
            {
                { "now", 4 }
            });
        }
        else if (skin_number_now == 5)
        {
            SendAnalytics("play_time", new Dictionary<string, object>
            {
                { "now", 5 }
            });
        }
        else if (skin_number_now == 6)
        {
            SendAnalytics("play_time", new Dictionary<string, object>
            {
                { "now", 6 }
            });
        }
        else if (skin_number_now == 7)
        {
            SendAnalytics("play_time", new Dictionary<string, object>
            {
                { "now", 7 }
            });
        }
        else if (skin_number_now == 8)
        {
            SendAnalytics("play_time", new Dictionary<string, object>
            {
                { "now", 8 }
            });
        }

    }
    public void Coin()
    {

        int coin_now = Variable_Manager.Instance.GetSetPossessionCoin;



        if (coin_now == 0)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 0 }
            });
        }
        else if (coin_now > 0 && coin_now < 1000)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 1000 }
            });
        }
        else if (coin_now >= 1000 && coin_now < 5000)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 5000 }
            });
        }
        else if (coin_now >= 5000 && coin_now < 10000)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 10000 }
            });
        }
        else if (coin_now >= 10000 && coin_now < 15000)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 15000 }
            });
        }
        else if (coin_now >= 15000 && coin_now < 20000)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 20000 }
            });
        }
        else if (coin_now >= 20000 && coin_now < 25000)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 25000 }
            });
        }
        else if (coin_now >= 25000 && coin_now < 30000)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 30000 }
            });
        }
        else if (coin_now >= 30000 && coin_now < 35000)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 35000 }
            });
        }
        else if (coin_now >= 35000 && coin_now < 40000)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 40000 }
            });
        }
        else if (coin_now >= 40000)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 99999 }
            });
        }

    }

   

    public void Title()
    {

        int play_game = Variable_Manager.Instance.GetSetPlayGames;



        if (play_game == 0)
        {
            SendAnalytics("game_play", new Dictionary<string, object>
            {
                { "play", 0 }
            });
        }
        else if (play_game > 0 && play_game < 1)
        {
            SendAnalytics("game_play", new Dictionary<string, object>
            {
                { "play", 1 }
            });
        }
        else if (play_game >= 1 && play_game < 3)
        {
            SendAnalytics("game_play", new Dictionary<string, object>
            {
                { "play", 3 }
            });
        }
        else if (play_game >= 3 && play_game < 5)
        {
            SendAnalytics("game_play", new Dictionary<string, object>
            {
                { "play", 5 }
            });
        }
        else if (play_game >= 5 && play_game < 10)
        {
            SendAnalytics("game_play", new Dictionary<string, object>
            {
                { "play", 10 }
            });
        }
        else if (play_game >= 10 && play_game < 20)
        {
            SendAnalytics("game_play", new Dictionary<string, object>
            {
                { "play", 20 }
            });
        }
        else if (play_game >= 20)
        {
            SendAnalytics("game_play", new Dictionary<string, object>
            {
                { "play", 99 }
            });
        }

    }

    public void Stage_Serect(int number)
    {
       
        
       
    

        int stage_number = number;

        if (stage_number == 1)
        {
            SendAnalytics("play_stage", new Dictionary<string, object>
            {
                { "Stage", 1 }
            });
        }
        else if (stage_number == 2)
        {
            SendAnalytics("play_stage", new Dictionary<string, object>
            {
                { "Stage", 2 }
            });
        }
        else if (stage_number == 3)
        {
            SendAnalytics("play_stage", new Dictionary<string, object>
            {
                { "Stage", 3 }
            });
        }
    }

    public void Stage1_Crash(float stage1_crash_rate)
    {

        //int stage1_crash_rate = Variable_Manager.Instance.GetSetPlayGames;



        if (stage1_crash_rate == 1)
        {
            SendAnalytics("stage1_rate", new Dictionary<string, object>
            {
                { "rate", 0 }
            });
        }
        else if (stage1_crash_rate > 0 && stage1_crash_rate < 20)
        {
            SendAnalytics("stage1_rate", new Dictionary<string, object>
            {
                { "rate", 20 }
            });
        }
        else if (stage1_crash_rate >= 20 && stage1_crash_rate < 40)
        {
            SendAnalytics("stage1_rate", new Dictionary<string, object>
            {
                { "rate", 40 }
            });
        }
        else if (stage1_crash_rate >= 40 && stage1_crash_rate < 60)
        {
            SendAnalytics("stage1_rate", new Dictionary<string, object>
            {
                { "rate", 60 }
            });
        }
        else if (stage1_crash_rate >= 60 && stage1_crash_rate < 80)
        {
            SendAnalytics("stage1_rate", new Dictionary<string, object>
            {
                { "rate", 80 }
            });
        }
        else if (stage1_crash_rate >= 80 && stage1_crash_rate < 100)
        {
            SendAnalytics("stage1_rate", new Dictionary<string, object>
            {
                { "rate", 100 }
            });
        }
        

    }

    public void Stage2_Crash(float stage2_crash_rate)
    {

        //int stage2_crash_rate = Variable_Manager.Instance.GetSetPlayGames;



        if (stage2_crash_rate == 2)
        {
            SendAnalytics("stage2_rate", new Dictionary<string, object>
            {
                { "rate", 0 }
            });
        }
        else if (stage2_crash_rate > 0 && stage2_crash_rate < 20)
        {
            SendAnalytics("stage2_rate", new Dictionary<string, object>
            {
                { "rate", 20 }
            });
        }
        else if (stage2_crash_rate >= 20 && stage2_crash_rate < 40)
        {
            SendAnalytics("stage2_rate", new Dictionary<string, object>
            {
                { "rate", 40 }
            });
        }
        else if (stage2_crash_rate >= 40 && stage2_crash_rate < 60)
        {
            SendAnalytics("stage2_rate", new Dictionary<string, object>
            {
                { "rate", 60 }
            });
        }
        else if (stage2_crash_rate >= 60 && stage2_crash_rate < 80)
        {
            SendAnalytics("stage2_rate", new Dictionary<string, object>
            {
                { "rate", 80 }
            });
        }
        else if (stage2_crash_rate >= 80 && stage2_crash_rate < 100)
        {
            SendAnalytics("stage2_rate", new Dictionary<string, object>
            {
                { "rate", 100 }
            });
        }


    }

    public void Stage3_Crash(float stage3_crash_rate)
    {

        //int stage3_crash_rate = Variable_Manager.Instance.GetSetPlayGames;



        if (stage3_crash_rate == 3)
        {
            SendAnalytics("stage3_rate", new Dictionary<string, object>
            {
                { "rate", 0 }
            });
        }
        else if (stage3_crash_rate > 0 && stage3_crash_rate < 20)
        {
            SendAnalytics("stage3_rate", new Dictionary<string, object>
            {
                { "rate", 20 }
            });
        }
        else if (stage3_crash_rate >= 20 && stage3_crash_rate < 40)
        {
            SendAnalytics("stage3_rate", new Dictionary<string, object>
            {
                { "rate", 40 }
            });
        }
        else if (stage3_crash_rate >= 40 && stage3_crash_rate < 60)
        {
            SendAnalytics("stage3_rate", new Dictionary<string, object>
            {
                { "rate", 60 }
            });
        }
        else if (stage3_crash_rate >= 60 && stage3_crash_rate < 80)
        {
            SendAnalytics("stage3_rate", new Dictionary<string, object>
            {
                { "rate", 80 }
            });
        }
        else if (stage3_crash_rate >= 80 && stage3_crash_rate < 100)
        {
            SendAnalytics("stage3_rate", new Dictionary<string, object>
            {
                { "rate", 100 }
            });
        }


    }

    public void Skin_Click(int skin_push)
    {
        //int skin_push = Variable_Manager.Instance.Skin_button_click;
        if (skin_push == 1)
        {
            SendAnalytics("skin_click", new Dictionary<string, object>
            {
                { "click", 1 }
            });
        }
    }

    public void reword(int reword_push)
    {
        //int skin_push = Variable_Manager.Instance.Skin_button_click;
        if (reword_push == 1)
        {
            SendAnalytics("reword_click", new Dictionary<string, object>
            {
                { "click", 1 }
            });
        }
    }

    public void Timer_on(int time_on)
    {
        if (time_on == 1)
        {
            SendAnalytics("on_time", new Dictionary<string, object>
            {
                { "click", 1 }
            });
        }
    }


    public void Timer_off(int time_off)
    {
        if (time_off == 1)
        {
            SendAnalytics("off_time", new Dictionary<string, object>
            {
                { "no_click", 1 }
            });
        }
    }

    public void Runk_Silver(int silver_now)
    {
        if (silver_now == 1)
        {
            SendAnalytics("silver_runk", new Dictionary<string, object>
            {
                { "runk", 2 }
            });
        }
    }

    public void Runk_Gold(int gold_now)
    {
        if (gold_now == 1)
        {
            SendAnalytics("gold_runk", new Dictionary<string, object>
            {
                { "runk", 3 }
            });
        }
    }

    public void PLay_times_number(int play_time_number)
    {
        

        
            SendAnalytics("stage_number_last", new Dictionary<string, object>
            {
                { "last_stage", play_time_number }
            });
        

    }



}
