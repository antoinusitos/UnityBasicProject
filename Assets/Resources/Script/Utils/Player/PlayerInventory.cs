using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool _isInInventory = false;

    public GameObject inventory;
    public GameObject map;

    private InputManager _inputManager;
    private CameraManager _cameraManager;

    private void Start()
    {
        _inputManager = InputManager.GetInstance();
        _cameraManager = CameraManager.GetInstance();
        inventory.SetActive(_isInInventory);
        map.SetActive(_isInInventory);
    }

    private void Update()
    {
        if(_inputManager.GetMenuPressed())
        {
            _isInInventory = !_isInInventory;
            OpenCloseInventory();
        }
    }

    private void OpenCloseInventory()
    {
        inventory.SetActive(_isInInventory);
        map.SetActive(_isInInventory);
        if(_isInInventory)
        {
            _cameraManager.SetCursorLocked(CursorLockMode.None);
        }
        else
        {
            _cameraManager.SetCursorLocked(CursorLockMode.Locked);
        }
    }
}
