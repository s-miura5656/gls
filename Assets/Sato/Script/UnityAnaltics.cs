using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class UnityAnaltics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int totalPotions = 5;
        int totalCoins = 100;
        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
        {
            { "potions", totalPotions },
            { "coins", totalCoins }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
