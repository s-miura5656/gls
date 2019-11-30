using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botton_clik : MonoBehaviour
{
    [SerializeField]
    private SmpleSphere script;

    private int avatar_number;

    void Start()
    {
      //  Variable_Manager.Instance.GetSetAvatarNumber = 0;
    }


    public void Number0_Clik()
    {

        Variable_Manager.Instance.GetSetAvatarNumber = 0;
        script.Set_avatar_number();
    }

    public void Number1_Clik()
    {

        Variable_Manager.Instance.GetSetAvatarNumber = 1;
        script.Set_avatar_number();
    }

    public void Number2_Clik()
    {

      
        Variable_Manager.Instance.GetSetAvatarNumber = 2;
        script.Set_avatar_number();
    }

    public void Number3_Clik()
    {

      
        Variable_Manager.Instance.GetSetAvatarNumber = 3;
        script.Set_avatar_number();
    }

    public void Number4_Clik()
    {

     
        Variable_Manager.Instance.GetSetAvatarNumber = 4;
        script.Set_avatar_number();
    }

    public void Number5_Clik()
    {

  
        Variable_Manager.Instance.GetSetAvatarNumber = 5;
        script.Set_avatar_number();

    }





}
