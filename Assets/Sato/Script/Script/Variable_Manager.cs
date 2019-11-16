using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable_Manager : SingletonMonoBehaviour<Variable_Manager>
{
    // Variable_Managerで保持したい変数
    private int playerExp = 0;

    public int PlayerExp
    {
        get { return playerExp; }
        set { playerExp = value; }
    }
}
