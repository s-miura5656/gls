using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Title : MonoBehaviour
{
    [SerializeField] private GameObject look_obj = null;

    private float angle = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        // タイトル用のカメラ回転用処理
        transform.LookAt(look_obj.transform);

        Vector3 axis = transform.TransformDirection(Vector3.up);

        transform.RotateAround(look_obj.transform.position, axis, angle * Time.deltaTime);
    }
}
