using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParentBall : MonoBehaviour
{
    [SerializeField]
    private GameObject[] balls;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hoge");
        foreach (var ball in balls)
        {
            if (ball.activeSelf)
            {
                ball.SetActive(false);
                break;
            }
        }
    }
}
