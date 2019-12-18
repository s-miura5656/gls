using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_Select : MonoBehaviour
{
    public void StageSelect(int number)
    {
        SceneManager.LoadScene("GameMain_" + number);
    }
}
