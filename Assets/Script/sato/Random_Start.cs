using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Start : MonoBehaviour
{
    [SerializeField]
    private GameObject random_gage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomStart()
    {
        random_gage.SetActive(true);
    }

}
