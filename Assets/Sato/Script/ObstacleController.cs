using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    private int Obstacle_state;
    private int Obstacle_time;
    public float Obstacle_speed;

    // Start is called before the first frame update
    void Start()
    {
        Obstacle_state = 0; 
        Obstacle_time = 0;
}
    
    // Update is called once per frame
    void FixedUpdate()
    {


        if(Obstacle_state == 0.0f)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y - Obstacle_speed, transform.position.z);
            if(this.transform.position.y <= 23.65)
            {
                Obstacle_state = 1;
            }
        }

        if (Obstacle_state == 1)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y + Obstacle_speed, transform.position.z);
            if (this.transform.position.y >= 29.89)
            {
                Obstacle_state = 0;
            }
        }

    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "player")
        {
            Destroy(col.gameObject);
        }

    }
}
