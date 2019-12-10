using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Title_Manager : MonoBehaviour
{
    [SerializeField]
    private Vibrations_Manager script;

    private int scene_number = 0;
    private int scene_number_min = 1;
    private int scene_number_max = 3;
                                                                                                                                                                                        
    public int game_start = 0;

    bool isFinishedSplashScreenAndPassedUpdate = false;


    [SerializeField]
    private UnityAnaltics Ana_script;

    // 最初に選ばれるステージの番号
    private int first_stage = 1;
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

        if (!UnityEngine.Rendering.SplashScreen.isFinished)
        {
                
            isFinishedSplashScreenAndPassedUpdate = true;
        }

        if (isFinishedSplashScreenAndPassedUpdate)
        {

            if (!Variable_Manager.Instance.GetSetStageState)
            {
                SceneManager.LoadScene("GameMain_" + first_stage);
                Variable_Manager.Instance.GetSetStageState = true;
            }
            else
            {
                scene_number = Random.Range(scene_number_min, scene_number_max);

                SceneManager.LoadScene("GameMain_" + scene_number);
            }

            game_start++;
            Variable_Manager.Instance.GetSetPlayGames = game_start;
        }

     
    }

    public void SetSkin() 
    {
        SceneManager.LoadScene("");
    }
}
