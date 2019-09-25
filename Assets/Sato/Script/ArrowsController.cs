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


    // Start is called before the first frame update
    void Start()
    {

        gameobject = GameObject.Find("player");
        charascript = gameobject.GetComponent<CharacterController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
            transform.localScale = new Vector3(distance/50, transform.localScale.y, transform.localScale.z);

        }

        



        if (Input.GetMouseButtonUp(0))
        {
            spriteRenderer.enabled = false;

            
        }


       



    }
}
