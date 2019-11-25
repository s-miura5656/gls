using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Title_Manager : MonoBehaviour
{
    [SerializeField]
    private Vibrations_Manager script;

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
        Variable_Manager.Instance.GetSetVibrate = script.status;
    }

    public void SetSkin() 
    {
        SceneManager.LoadScene("");
    }
}
