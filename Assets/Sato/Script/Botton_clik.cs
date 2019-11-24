using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botton_clik : MonoBehaviour
{

    private int avatar_number;

    void Start()
    {
      //  Variable_Manager.Instance.GetSetAvatarNumber = 0;
    }


    public void Number0_Clik()
    {

        Variable_Manager.Instance.GetSetAvatarNumber = 0;
    }

    public void Number1_Clik()
    {

        Variable_Manager.Instance.GetSetAvatarNumber = 1;
    }

    public void Number2_Clik()
    {

      
        Variable_Manager.Instance.GetSetAvatarNumber = 2;
    }

    public void Number3_Clik()
    {

      
        Variable_Manager.Instance.GetSetAvatarNumber = 3;
    }

    public void Number4_Clik()
    {

     
        Variable_Manager.Instance.GetSetAvatarNumber = 4;
    }

    public void Number5_Clik()
    {

  
        Variable_Manager.Instance.GetSetAvatarNumber = 5;

    }





}
