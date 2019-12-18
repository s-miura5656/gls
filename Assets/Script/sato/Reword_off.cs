using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reword_off : MonoBehaviour
{
    [SerializeField]
    private Image line_reword;

    [SerializeField]
    private Button reword;


    public float waitTime = 30.0f;
    public float waitTime_carve = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //line_reword.fillAmount -= 1.0f / waitTime * Time.deltaTime;
        //if(line_reword.fillAmount == 1.0 || line_reword.fillAmount >=0.9)
        //{
        //    line_reword.fillAmount -= 1.0f / waitTime * Time.deltaTime;
        //}

        //if (line_reword.fillAmount < 0.9 || line_reword.fillAmount >= 0.6)
        //{
        //    line_reword.fillAmount -= 1.0f / waitTime_carve * Time.deltaTime;
        //}

        //if (line_reword.fillAmount < 0.6 || line_reword.fillAmount >= 0.4)
        //{
        //    line_reword.fillAmount -= 1.0f / waitTime * Time.deltaTime;
        //}

        //if (line_reword.fillAmount < 0.4 || line_reword.fillAmount >= 0.1)
        //{
        //    line_reword.fillAmount -= 1.0f / waitTime_carve * Time.deltaTime;
        //}

        //if (line_reword.fillAmount < 0.1 || line_reword.fillAmount <= 0.0)
        //{
        //    line_reword.fillAmount -= 1.0f / waitTime * Time.deltaTime;
        //}



        //if (line_reword.fillAmount <= 0)
        //{
        //    reword.gameObject.SetActive(false);
        //}
    }
}
