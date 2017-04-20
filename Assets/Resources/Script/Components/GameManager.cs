using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BaseManager 
{

    // -----------------------------------------------------------------------------------------

    public override void InitManagerForEditor()
    {

    }



    //
    // Singleton Stuff
    // 

    private static GameManager _instance;

    public static GameManager GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }
}
