using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : BaseManager
{

    // -----------------------------------------------------------------------------------------

    public override void InitManagerForEditor()
    {

    }



    //
    // Singleton Stuff
    // 

    private static InputManager _instance;

    public static InputManager GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }
}
