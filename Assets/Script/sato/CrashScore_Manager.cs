using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class CrashScore_Manager : MonoBehaviour

{
    [SerializeField]
    private GameObject crash_score;

    private GameObject date;


    private Variable_Manager script;

    private float score = 0;


    private Text crash_score_text;


    public float crash_count;
    private int test_count;

    private int crash_rate;



    void Start()
    {
        crash_count = Variable_Manager.Instance.GetSetDestructionRate;
        //Crash_Manager();
    

    }

    // Update is called once per frame
    void Update()
    {
        crash_score_text = crash_score.GetComponent<Text>();
        crash_score_text.text = crash_count.ToString("f2") + " ％" ;
    }

    

}


