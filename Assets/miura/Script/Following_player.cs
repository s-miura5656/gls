using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following_player : MonoBehaviour
{
    // 追従するオブジェクトのスピード
    [SerializeField] private float m_speed = 5;
    // 
    [SerializeField] private float m_attenuation = 0.5f;
    // 距離の値
    [SerializeField] private float dist_number = 10;
    // プレイヤーとの距離
    private float dist;
    private Vector3 m_velocity;
    // プレイヤー
    private GameObject player;

    private float dist_x;
    private float dist_z;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        dist = (transform.position - player.transform.position).sqrMagnitude;

        //Debug.Log(dist);

        if (dist >= (dist_number * dist_number))
        {
            m_velocity += (player.transform.position - transform.position) * m_speed;
            m_velocity *= m_attenuation;
            m_velocity *= Time.deltaTime;
            transform.position += m_velocity;
        }

        //dist_x = transform.position.x - player.transform.position.x;
        //dist_z = transform.position.z - player.transform.position.z;

        //transform.position += new Vector3(player.transform.position.x + dist_x, 0f, player.transform.position.z + dist_z);

    }
}
