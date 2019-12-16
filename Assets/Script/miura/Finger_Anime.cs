using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finger_Anime : MonoBehaviour
{
    [SerializeField] private RectTransform finger = null;
    [SerializeField] private RectTransform arrow = null;
    [SerializeField] private player_controller_move player_controller_move_script = null;

    private Vector3 default_finger_pos = Vector3.zero;
    private Vector3 default_arrow_scale = Vector3.one;
    // Start is called before the first frame update
    void Start()
    {
        default_finger_pos = finger.transform.position;
        default_arrow_scale = arrow.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (finger.transform.localPosition.y >= -500f)
        {
            finger.transform.position += new Vector3(0f, -200f, 0f) * Time.deltaTime;
            arrow.transform.localScale += new Vector3(0.5f, 0f, 0f) * Time.deltaTime;
        }
        else
        {
            finger.transform.position = default_finger_pos;
            arrow.transform.localScale = default_arrow_scale;
        }
    }


    private void OnDisable()
    {
        finger.transform.position = default_finger_pos;
        arrow.transform.localScale = default_arrow_scale;
    }
}
