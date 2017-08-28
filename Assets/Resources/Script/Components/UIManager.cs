using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : BaseManager
{
    public Text objectName;
    public Text actionName;
    public GameObject[] textsToShow;

    public enum ActionType
    {
        None,
        Pickup,
        Open,
        Close,
        //...
    }
    private ActionType _currentActionType = ActionType.None;

    private void Start()
    {
        HideObjectName();
    }

    public void SetObjectName(string name)
    {
        objectName.text = name;
        for(int i = 0; i < textsToShow.Length; i++)
        {
            textsToShow[i].SetActive(true);
        }
    }

    public void SetActionType(ActionType newActionType)
    {
        _currentActionType = newActionType;
    }

    public void SetActionName(string name)
    {
        actionName.text = name + " to " + _currentActionType.ToString();
    }

    public void HideObjectName()
    {
        for (int i = 0; i < textsToShow.Length; i++)
        {
            textsToShow[i].SetActive(false);
        }
    }

    // -----------------------------------------------------------------------------------------

    public override void InitManagerForEditor()
    {

    }



    //
    // Singleton Stuff
    // 

    private static UIManager _instance;

    public static UIManager GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        _instance = this;
    }
}
