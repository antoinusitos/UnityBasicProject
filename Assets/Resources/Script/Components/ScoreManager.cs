using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : BaseManager
{

    // -----------------------------------------------------------------------------------------

    public override void InitManagerForEditor()
    {

    }



    //
    // Singleton Stuff
    // 

    private static ScoreManager _instance;

    public static ScoreManager GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }
}
