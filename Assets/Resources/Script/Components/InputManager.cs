using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : BaseManager
{

    public bool GetEnterPressed()
    {
        return Input.GetKeyDown(KeyCode.KeypadEnter);
    }

    public bool GetSpacePressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public bool GetEscapePressed()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

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
