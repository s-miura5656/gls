using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class UnityAnaltics : SingletonMonoBehaviour<UnityAnaltics>
{
    // Start is called before the first frame update
    void Start()
    {
        //タイトルだけ送るパターン
        SendAnalytics("gameOver");

        int 破壊率 = 30;

        if (破壊率 >= 0 && 破壊率 < 30)
        {
            SendAnalytics("clash", new Dictionary<string, object>
            {
                { "%", 30 }
            });
        }
        else if (破壊率 >= 30 && 破壊率 < 70)
        {
            SendAnalytics("clash", new Dictionary<string, object>
            {
                { "%", 70 }
            });
        }
        else if (破壊率 >= 70 && 破壊率 < 80)
        {
            SendAnalytics("clash", new Dictionary<string, object>
            {
                { "%", 80 }
            });
        }
        else if (破壊率 >= 80 && 破壊率 <= 100)
        {
            SendAnalytics("clash", new Dictionary<string, object>
            {
                { "%", 100 }
            });
        }

        // タイトルとデータを送るパターン
        SendAnalytics("gameOver", new Dictionary<string, object>
        {
            { "potions", 5 },
            { "coins", 100 }
        });
    }

    public void SendAnalytics(string title)
    {
        Analytics.CustomEvent(title);
    }

    public void SendAnalytics(string title, Dictionary<string, object > data)
    {
        Analytics.CustomEvent(title, data);
    }
}
