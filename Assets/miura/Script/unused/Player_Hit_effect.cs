using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hit_effect : MonoBehaviour
{
    [SerializeField] private GameObject hit_effect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Bill_Level_1")
        {
            float size = transform.localScale.x;

            GameObject hit_copy = Instantiate(hit_effect, transform.position + (transform.forward * size), Quaternion.identity);

            Destroy(hit_copy, 1f);
        }

        if (other.gameObject.tag == "Bill_Level_2")
        {
            float size = transform.localScale.x;

            GameObject hit_copy = Instantiate(hit_effect, transform.position + (transform.forward * size), Quaternion.identity);

            Destroy(hit_copy, 1f);
        }

        if (other.gameObject.tag == "Bill_Level_3")
        {
            float size = transform.localScale.x;

            GameObject hit_copy = Instantiate(hit_effect, transform.position + (transform.forward * size), Quaternion.identity);

            Destroy(hit_copy, 1f);
        }
    }
}
