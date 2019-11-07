using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Konami_Camera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float alpha = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        // メインカメラからプレイヤーの位置へレイをとばす
        Ray ray = Camera.main.ScreenPointToRay(player.transform.position);


        if (Physics.Raycast(ray, out hit, 100f))
        {
            MeshRenderer mesh = hit.collider.GetComponent<MeshRenderer>();

            if (alpha == 1f)
            {
                alpha = 0.5f;
                mesh.material.color = new Color(mesh.material.color.r, mesh.material.color.g, mesh.material.color.b, alpha);
            }
        }
        else
        {
            
        }
        
    }
}
