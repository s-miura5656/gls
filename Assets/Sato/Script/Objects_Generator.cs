using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects_Generator : MonoBehaviour
{
    [SerializeField] private GameObject[] game_objects;

    private void Awake()
    {
        for (int i = 0; i < game_objects.Length; i++)
        {
            Instantiate(game_objects[i]);
        }
    }
}
