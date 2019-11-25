using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraLookSprite : MonoBehaviour
{

    private Camera _camera = null;
    private GameObject player = null;
    private GameObject debug_text = null;
    private TextMeshProUGUI text = null;
    private float obj_pos_y = 0f;

    // Start is called before the first frame update
    void Start()
    {
        debug_text = GameObject.Find("Debug");
        text = debug_text.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate(){

        if (_camera == null)
        {
            return;
        }

        text.text = "" + gameObject.transform.position;

        transform.position = new Vector3(player.transform.position.x, player.transform.localScale.y + obj_pos_y, player.transform.position.z);
        transform.position = new Vector3(player.transform.position.x, player.transform.localScale.y + obj_pos_y, player.transform.position.z);
        transform.position = new Vector3(player.transform.position.x, player.transform.localScale.y + obj_pos_y, player.transform.position.z);


        obj_pos_y += 0.1f;

        if (transform.position.y >= player.transform.localScale.y + 10f)
        {
            Destroy(gameObject);
        }

        transform.LookAt(_camera.transform);
    }

    /// <summary>
    /// カメラの取得
    /// </summary>
    /// <param name="taget"></param>
    public void SetCamera(Camera taget)
    {
        _camera = taget;
    }

    /// <summary>
    /// プレイヤーの取得
    /// </summary>
    /// <param name="player_obj"></param>
    public void SetPlayerObj(GameObject player_obj) 
    {
        player = player_obj;
    }

}
