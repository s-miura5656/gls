using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    private GameObject heisi;

    // Start is called before the first frame update
    void Start()
    {
        GameObject heisi = GameObject.Find("heisi");
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "player")
        {
            Destroy(GameObject.FindGameObjectWithTag("Finish"));
        }

    }
}

