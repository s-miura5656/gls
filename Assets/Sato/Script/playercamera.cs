using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercamera : MonoBehaviour
{
    public GameObject Sphere;
    Vector3 offset;

    //public static Camera main { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        //if (main == null)
        //    main = this;

        offset = this.transform.position - Sphere.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       // this.transform.position = new Vector3(Sphere.transform.position.x, Sphere.transform.position.y, this.transform.position.z) + new Vector3(offset.x, offset.y, 0);
        this.transform.position = new Vector3(this.transform.position.x, Sphere.transform.position.y, this.transform.position.z) + new Vector3(0, offset.y, 0);
    }

    internal Vector3 ScreenToWorldPoint(Vector3 position)
    {
        throw new NotImplementedException();
    }

 
}
