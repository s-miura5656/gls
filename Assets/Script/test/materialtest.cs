using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialtest : MonoBehaviour
{
    public GameObject body;
    // Start is called before the first frame update
    //public Material[] _material;  
    // 割り当てるマテリアル.

    //色
    private int i;
    //色の個数
    public Color[] col;
    //建物の個数
    private GameObject[] test;

   
    // Use this for initialization
    void Start()
    {
       
        i = 0;

        test = GameObject.FindGameObjectsWithTag("test");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            i++;
            if (i == 2)
            {
                i = 0;
            }

            //body.GetComponent<Renderer>().material = _material[i];
            //body.GetComponent<Renderer>().material.color = col[i];


            for (int a = 0; a < test.Length; a++)
            {

                test[a].GetComponent<Renderer>().material.color = col[i];
            }
        }

    }

}
