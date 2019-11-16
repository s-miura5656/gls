using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bill_Hit_effect : MonoBehaviour
{
    [SerializeField] private GameObject hit_effect;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject hit_copy = Instantiate(hit_effect, player.transform.forward * 1, Quaternion.identity);

            Destroy(hit_copy, 1.5f);
        }
    }

    
}
