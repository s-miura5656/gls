using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookSprite : MonoBehaviour
{

    private Camera _camera = null;
    private GameObject player = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate(){

        if (_camera == null)
        {
            return;
        }

        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

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
