using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsController : MonoBehaviour
{
    public Transform target;
    GameObject gameobject;
    CharacterController charascript;
    public Vector3 startDirection;
    public Vector3 arrowsdirection;
    public Vector3 arrowsstartPos;
    public Vector3 touchPos;
    private Vector2 startpos;
    private SpriteRenderer spriteRenderer;
    public float distance;

    private float delta_time = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        distance = 0.0f;
        gameobject = GameObject.Find("player");
        charascript = gameobject.GetComponent<CharacterController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        delta_time += Time.deltaTime;
        if (delta_time < 0.1f)
            return;

        Vector3 tmp = GameObject.Find("player").transform.position;
        transform.position = tmp;
        



        if (Input.GetMouseButtonDown(0))
        {
            spriteRenderer.enabled = true;
        }


        if (Input.GetMouseButton(0))
        {
            float angle = Mathf.Atan2(charascript.startPos.y - Input.mousePosition.y, charascript.startPos.x - Input.mousePosition.x );
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle * Mathf.Rad2Deg));
            distance = (charascript.startPos - Input.mousePosition).magnitude;
            if(distance >= 200.0f)
            {
                distance = 200.0f;
            }

            if (distance <= 30.0f)
            {
                distance = 30.0f;
            }

            transform.localScale = new Vector3(distance/50, transform.localScale.y, transform.localScale.z);

        }

        



        if (Input.GetMouseButtonUp(0))
        {
            spriteRenderer.enabled = false;

            
        }


       



    }
}
