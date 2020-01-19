using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skin_select_switch : MonoBehaviour
{
    [SerializeField]
    private Button normal_screen = null;
    [SerializeField]
    private GameObject normal_screen_rect;
    [SerializeField]
    private Button special_screen = null;
    [SerializeField]
    private GameObject special_screen_rect;

    private Vector3 off_vector = new Vector3(1,0,1);
    private Vector3 on_vector = new Vector3(1, 1, 1);

    void Start()
    {
        normal_screen.onClick.AddListener(Open_normal_screen);
        special_screen.onClick.AddListener(Open_special_screen);
    }

    void Update()
    {
        
    }

    private void Open_normal_screen()
    {
        normal_screen_rect.transform.localScale = on_vector;
        special_screen_rect.transform.localScale = off_vector;
    }

    private void Open_special_screen()
    {
        normal_screen_rect.transform.localScale = off_vector;
        special_screen_rect.transform.localScale = on_vector;

    }


}
