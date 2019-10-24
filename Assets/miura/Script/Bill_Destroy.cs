using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bill_Destroy : MonoBehaviour
{
    // ビルが壊れるアニメーション
    [SerializeField] private GameObject bill_destroy;
    // ビルのアニメの取得
    private Animator bill_destroy_anime;

    // Start is called before the first frame update
    void Start()
    {
        bill_destroy_anime = bill_destroy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bill_destroy_anime.SetTrigger("destroy");
        }   
    }
}
