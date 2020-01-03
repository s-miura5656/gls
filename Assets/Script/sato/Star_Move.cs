using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star_Move : MonoBehaviour
{

    [SerializeField]
    private GameObject star;
    [SerializeField]
    private GameObject goal;

    //private Vector3 start_pos;
    //private Vector3 goal_pos;
    private Vector3 distance;
    [SerializeField]
    private float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
      var  dis = goal.gameObject.transform.position - star.gameObject.transform.position;
        distance = dis.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        star.gameObject.transform.position += distance * speed;
    }

    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D collider)
    {
        DestroyObject(gameObject);
    }

   public void Goal_Set(GameObject _goal)
    {
        goal = _goal;
    }
}
