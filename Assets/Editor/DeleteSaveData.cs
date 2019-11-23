using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSaveData : MonoBehaviour
{
    [UnityEditor.MenuItem("Teruteru/DeleteSaveData")]
    public static void Delete()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("delete all save data");
    }
}
