using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MainManu()
    {
        SceneManager.LoadScene("Title_");
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("GameMain_1");
    }
}