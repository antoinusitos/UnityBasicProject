using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private InputManager _inputManager;
    private PlayerInventory _playerInventory;
    private Transform _mainCam;

    private void Start()
    {
        _inputManager = InputManager.GetInstance();
        _playerInventory = GetComponent<PlayerInventory>();
        _mainCam = Camera.main.transform;
    }

    private void Update()
    {
        if(_inputManager.GetActionPressed())
        {
            RaycastHit hit;
            if (Physics.Raycast(_mainCam.position, _mainCam.forward, out hit, 100))
            {
                AItem item = hit.collider.GetComponent<AItem>();
                if(item)
                {
                    _playerInventory.AddItemWithObject(item.infos);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

}