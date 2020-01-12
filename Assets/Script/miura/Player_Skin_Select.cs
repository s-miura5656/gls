using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player_Skin_Select : MonoBehaviour
{
    // プレイヤースキン種類
    [SerializeField] private GameObject[] players = null;
    [SerializeField] private SphereCollider sphere_collider = null;
    [SerializeField] private CapsuleCollider capsule_collider = null;

    void Start()
    {
        GameObject childObject = Instantiate(players[Variable_Manager.Instance.GetSetAvatarNumber],
                                             gameObject.transform.position,
                                             players[Variable_Manager.Instance.GetSetAvatarNumber].transform.rotation);

        childObject.transform.localScale *= gameObject.transform.localScale.y;
        childObject.transform.parent = this.transform;

        if (Variable_Manager.Instance.GetSetAvatarNumber == 0)
        {
            capsule_collider.enabled = true;
            sphere_collider.enabled = false;
        }
        else
        {
            capsule_collider.enabled = false;
            sphere_collider.enabled = true;
        }
    }
}
