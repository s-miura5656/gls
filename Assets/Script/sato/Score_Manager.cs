using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject score;
    
    private Text score_date;

    void Start()
    {
        score_date = score.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
