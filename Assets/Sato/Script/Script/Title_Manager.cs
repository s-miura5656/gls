using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Title_Manager : MonoBehaviour
{
    [SerializeField]
    private Vibrations_Manager script;

    private int scene_number = 1;
    private int scene_number_min = 1;
    private int scene_number_max = 3;

    public int game_start = 0;

    [SerializeField]
    private UnityAnaltics Ana_script;

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }
    // Start is called before the first frame update
    void Start()
    {
        game_start = Variable_Manager.Instance.GetSetPlayGames;
    }

    // Update is called once per frame
    void Update()
    {
        //scene_number = Random.Range(scene_number_min, scene_number_max);
        //Debug.Log(scene_number);
    }

    public void PlayGame() 
    {
        //Variable_Manager.Instance.GetSetVibrate = script.GetStatus();
        
        //scene_number = Random.Range(scene_number_min, scene_number_max);

        //SceneManager.LoadScene("GameMain_" + scene_number);

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameMain_2");
        game_start++;
        Variable_Manager.Instance.GetSetPlayGames = game_start;

    }

    public void SetSkin() 
    {
        SceneManager.LoadScene("");
    }
}
