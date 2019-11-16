using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Title_Manager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 30;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame() 
    {
        SceneManager.LoadScene("GameMain_1");
    }

    public void SetSkin() 
    {
        SceneManager.LoadScene("");
    }
}
