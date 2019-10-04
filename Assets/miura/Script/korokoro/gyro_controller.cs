using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gyro_controller : MonoBehaviour
{
    private GameObject m_sphere;
    private Rigidbody rigidbody;
    [SerializeField] private GameObject gyro_pos;
    private Vector3 gravityV;
    // Start is called before the first frame update
    void Start()
    {
        // シーン上のSphere名義の球のGameObjectを保持.
        m_sphere = GameObject.Find("/Player") as GameObject;
        rigidbody = m_sphere.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // ジャイロのPOSをテキストに出す
        Text _text = gyro_pos.GetComponent<Text>();
        _text.text = "" + gravityV;

        Input.gyro.enabled = true;
        // ジャイロから重力の下向きのベクトルを取得。水平に置いた場合は、gravityV.zが-9.8になる.
        gravityV = Input.gyro.gravity;

        // 外力のベクトルを計算.
        float scale = 200.0f;
        Vector3 forceV = new Vector3(gravityV.x, 0.0f, gravityV.y) * scale;

        // m_sphereに外力を加える.
        rigidbody.AddForce(forceV);
    }
}
