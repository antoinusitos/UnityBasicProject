using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BaseManager 
{

    public void Win()
    {

    }

    public void Loose()
    {

    }

    public void StartGame()
    {

    }

    public void StartMenu()
    {

    }

    private void Reset()
    {

    }

    public void Restart()
    {
        StartCoroutine(TimerRestart(3.0f));
    }

    IEnumerator TimerRestart(float time)
    {
        yield return new WaitForSeconds(time);
        StartMenu();
    }

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
