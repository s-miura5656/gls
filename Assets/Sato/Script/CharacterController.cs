using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    Rigidbody rigid2d;
    public Vector3 startPos;
    public float speed;
    public Vector2 startDirection;
    GameObject gameobject;
    ArrowsController arrowsscript;
    public Vector3 velo;
    public Vector3 vec;




    void Start()
    {
        gameobject = GameObject.Find("arrows");
        arrowsscript = gameobject.GetComponent<ArrowsController>();
        this.rigid2d = GetComponent<Rigidbody>();
       


    }

    void Update()
    {
    
        vec = gameobject.transform.right;

        // マウスの動きと反対方向に発射される
        if (Input.GetMouseButtonDown(0))
        {
            this.rigid2d.velocity = Vector3.Normalize(this.rigid2d.velocity) * 3.0f;
            this.startPos = Input.mousePosition;
            startDirection *= 0;
            
        }

        else if (Input.GetMouseButtonUp(0))
        {
            this.rigid2d.velocity = Vector3.zero;
            Vector3 endPos = Input.mousePosition;
            startDirection = -1 * (endPos - startPos).normalized;
            this.rigid2d.AddForce(gameobject.transform.right * arrowsscript.distance * speed * 0.01f, ForceMode.VelocityChange);
            

        }

            // テスト用：スペースキー押下で停止
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    this.rigid2d.velocity *= 0;
            //}

        


        // Spaceキーを離すと動き出す
        //if(Input.GetKeyUp(KeyCode.Space)) {
        //
        //	this.speed = 100.0f;
        //	this.rigid2d.AddForce(transform.up * speed);
        //}

    }

}