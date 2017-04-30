using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{

    private bool _canMove = true;

    public int indexPlayer = 0;
    public bool useGamepad = true;
    public bool useKeyboard = true;

    // Accessor
    private InputManager _inputManager;
    private GamepadManager _gamepadManager;

    private void Start()
    {
        _inputManager = InputManager.GetInstance();
        _gamepadManager = GamepadManager.GetInstance();
    }

    private void Update()
    {
        if (_canMove)
        {
            if(useGamepad)
            {
                Debug.Log(_gamepadManager.GetStickPosX());
                if(_gamepadManager.AButtonPressed())
                {
                    Debug.Log("A Button Pressed");
                }
            }

            if(useKeyboard)
            {
                if (_inputManager.GetSpaceBarPressed())
                {
                    Debug.Log("Space Bar Pressed");
                }
                if (_inputManager.GetSpaceBarReleased())
                {
                    Debug.Log("Space Bar Released");
                }
                if (_inputManager.GetSpaceBarState())
                {
                    Debug.Log("Space Bar Input");
                }
            }
        }
    }
}
