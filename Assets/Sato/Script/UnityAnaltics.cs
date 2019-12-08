using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class UnityAnaltics : SingletonMonoBehaviour<UnityAnaltics>
{

    [SerializeField]
    private Skin_RandomSerect serect_script;
    [SerializeField]
    private Variable_Manager manager_script;
    [SerializeField]
    private Title_Manager title_script;


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
        Debug.Log(title);
        Analytics.CustomEvent(title, data);
    }

    public void open_number()
    {


        int open_number = serect_script.open_numbers;

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

    public void Skin_now()
    {

        int skin_number_now = Variable_Manager.Instance.GetSetAvatarNumber;



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
        else if (coin_now >= 1000 && coin_now < 2000)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 2000 }
            });
        }
        else if (coin_now >= 2000 && coin_now < 3000)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 3000 }
            });
        }
        else if (coin_now >= 3000 && coin_now < 5000)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 5000 }
            });
        }
        else if (coin_now >= 5000 && coin_now < 8000)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 8000 }
            });
        }
        else if (coin_now >= 8000)
        {
            SendAnalytics("possession_coin", new Dictionary<string, object>
            {
                { "yen", 9999 }
            });
        }

    }

   

    public void Title()
    {

        int play_game = title_script.game_start;



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
}
