using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following_player : MonoBehaviour
{
    // 追従するオブジェクトのスピード
    [SerializeField] private float m_speed = 1;
    // 
    [SerializeField] private float m_attenuation = 0.5f;
    // 距離の値
    [SerializeField] private float dist_number = 10;
    // プレイヤーとの距離
    private float dist;
    private Vector3 old_player_pos;
    // プレイヤー
    private GameObject player;

    private float time_count;
    private float time_max;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        time_count += Time.deltaTime;

        dist = (transform.position - player.transform.position).sqrMagnitude;

        old_player_pos = player.transform.position;

        transform.position += Vector3.Normalize(old_player_pos - transform.position) * m_speed;
        
    }
}
