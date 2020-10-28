using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_controller_move : MonoBehaviour
{
    [SerializeField] private Rigidbody rb = null;
    private Vector3 start_pos = Vector3.zero;
    private Vector3 end_pos = Vector3.zero;
    private Vector3 player_default_pos = Vector3.zero;

    //! 離したときにプレイヤーにかける力
    private Vector3 start_direction = Vector3.zero;
    
    //! 離したときにプレイヤーにかける力に追加する値
    private float powor = 0f;
    
    //! プレイヤーの速度の下限値
    private float lower_limit_speed = 5f;
    
    [Header("GameManagerを入れる")]
    [SerializeField] private GameObject game_manager = null;
    [Header("GameManagerを入れる")]
    [SerializeField] private Time_Manager time_script = null;
    [Header("GameManagerを入れる")]
    [SerializeField] private Player_Level_Manager player_level_manager_script = null;
    [Header("PlayerのColliderを入れる")]
    [SerializeField] private SphereCollider sphere_collider = null;
    [Header("Operation_Explanationを入れる")]
    [SerializeField] private GameObject operation_anime = null;
    [Header("PlayerParametor(ScriptableObject)を入れる")]
    [SerializeField] private PlayerParametor player_parametor_script = null;

    //! プレイヤーのレベルが上がっていくにつれて加える力
    private float[] player_powor;
    //! 落ちたときのリセットがかかる位置
    private const float reset_pos = -200f;
    private const int gravity = -80;
    void Start()
    {
        player_powor = new float[player_level_manager_script.PlayerLevelMax];

        for (int i = 0; i < player_powor.Length; i++)
        {
            player_powor[i] = player_parametor_script.PlayerPowor[i];
        }

        player_default_pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        PullController();
        
        MoveStop();

        ReStart();

        //! 時間切れで止まる
        if (!time_script.GetGamePlayState)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        //! プレイヤーに重力をかける
        rb.AddForce(new Vector3(0, gravity, 0), ForceMode.Acceleration);
    }

    private void FixedUpdate()
    {
        FowardRotation();
    }

    /// <summary>
    /// 進行方向へ回転させる
    /// </summary>
    private void FowardRotation()
    {
        var translation = rb.velocity * Time.deltaTime;

        var distance = translation.magnitude;

        var scaleXYZ = transform.lossyScale;

        var scale = Mathf.Max(scaleXYZ.x, scaleXYZ.y, scaleXYZ.z);

        var angle = distance / (sphere_collider.radius * scale);

        var axis = Vector3.Cross(Vector3.up, translation).normalized;

        var deltaRotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, axis);

        rb.MoveRotation(deltaRotation * rb.rotation);
    }

    /// <summary>
    /// 引っ張り操作
    /// </summary>
    private void PullController()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            this.start_pos = Input.mousePosition;

            start_direction *= 0;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            end_pos = Input.mousePosition;

            powor = (player_parametor_script.DistFlat * player_powor[player_level_manager_script.GetLevel() - 1]);

            powor *= player_parametor_script.PlayerSkinPramSpeed[Variable_Manager.Instance.GetSetAvatarNumber];

            start_direction = (start_pos - end_pos).normalized;

            //! カウントダウン後動けるようになる
            if (time_script.GetGamePlayState)
            {
                rb.AddForce(new Vector3(start_direction.x * powor, 0f, start_direction.y * powor), ForceMode.Impulse);
            }
        }
    }

    /// <summary>
    /// 停止
    /// </summary>
    private void MoveStop()
    {
        if (rb.velocity.magnitude <= lower_limit_speed)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        //! 操作説明のアニメの再生と停止
        if (Variable_Manager.Instance.Serect_Stage == 0)
        {
            if (rb.velocity.magnitude < player_parametor_script.AnimationStart)
            {
                if (!operation_anime.activeSelf)
                    operation_anime.SetActive(true);
            }
            else
            {
                if (operation_anime.activeSelf)
                    operation_anime.SetActive(false);
            }
        }
    }

    /// <summary>
    /// 場外に落ちたらリスタート
    /// </summary>
    private void ReStart() 
    {
        if (transform.position.y < reset_pos)
        {
            transform.position = player_default_pos + new Vector3(0, transform.localScale.y / 2f, 0);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void Reset()
    {
        game_manager = GameObject.Find("GameManager");
        rb = gameObject.GetComponent<Rigidbody>();
        sphere_collider = gameObject.GetComponent<SphereCollider>();
        time_script = game_manager.GetComponent<Time_Manager>();
        player_level_manager_script = game_manager.GetComponent<Player_Level_Manager>();
    }
}
