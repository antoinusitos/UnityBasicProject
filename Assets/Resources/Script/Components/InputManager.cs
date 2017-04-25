using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class InputManager : BaseManager
{

    private float _triggerDeadZone = 0.5f;

    private PlayerIndex _playerIndex;
    private GamePadState _state;
    private GamePadState _prevState;

    void Update ()
    {
        PlayerIndex testPlayerIndex = (PlayerIndex)0;
        GamePadState testState = GamePad.GetState(testPlayerIndex);
        if (testState.IsConnected)
        {
            _playerIndex = testPlayerIndex;
        }

        _prevState = _state;
        _state = GamePad.GetState(testPlayerIndex);
    }

    public void Vibration(int index)
    {
        GamePad.SetVibration((PlayerIndex)index, 1.0f, 1.0f);
    }

    public float GetStickPosX()
    {
        return _state.ThumbSticks.Left.X;
    }

    public float GetStickPosY()
    {
        return _state.ThumbSticks.Left.Y;
    }

    public bool RightTriggerPressed()
    {
        return _state.Triggers.Right >= _triggerDeadZone ? true : false;
    }

    public bool LeftTriggerPressed()
    {
        return _state.Triggers.Left >= _triggerDeadZone ? true : false;
    }

    public bool BButtonPressed()
    {
        if(_prevState.Buttons.B == ButtonState.Released && _state.Buttons.B == ButtonState.Pressed)
        {
            return true;
        }
        return false;
    }

    public bool AButtonPressed()
    {
        if (_prevState.Buttons.A == ButtonState.Released && _state.Buttons.A == ButtonState.Pressed)
        {
            return true;
        }
        return false;
    }

    public bool XButtonPressed()
    {
        if(_prevState.Buttons.X == ButtonState.Released && _state.Buttons.X == ButtonState.Pressed)
        {
            return true;
        }
        return false;
    }

    public bool YButtonPressed()
    {
        if (_prevState.Buttons.Y == ButtonState.Released && _state.Buttons.Y == ButtonState.Pressed)
        {
            return true;
        }
        return false;
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
