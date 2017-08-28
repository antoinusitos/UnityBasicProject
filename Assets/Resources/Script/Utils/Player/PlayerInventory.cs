using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool _isInInventory = false;

    public GameObject inventoryUI;
    public GameObject mapUI;

    private InputManager _inputManager;
    private CameraManager _cameraManager;

    public List<Item> inventory;
    private int _maximumQuantity = 5;

    [System.Serializable]
    public struct Item
    {
        public int Id;
        public string Name;
        public int Quantity;
        public Item(int theId = -1, string theName = "UNKNOWN", int theQuantity = 0)
        {
            Id = theId;
            Name = theName;
            Quantity = theQuantity;
        }
    }

    private void Start()
    {
        _inputManager = InputManager.GetInstance();
        _cameraManager = CameraManager.GetInstance();
        inventoryUI.SetActive(_isInInventory);
        mapUI.SetActive(_isInInventory);

        inventory = new List<Item>();
    }

    private void Update()
    {
        if(_inputManager.GetMenuPressed())
        {
            _isInInventory = !_isInInventory;
            OpenCloseinventoryUI();
        }
    }

    private void OpenCloseinventoryUI()
    {
        inventoryUI.SetActive(_isInInventory);
        mapUI.SetActive(_isInInventory);
        if(_isInInventory)
        {
            _cameraManager.SetCursorLocked(CursorLockMode.None);
        }
        else
        {
            _cameraManager.SetCursorLocked(CursorLockMode.Locked);
        }
    }

    private int GetNumberFromID(int theID)
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i].Id == theID)
            {
                return inventory[i].Quantity;
            }
        }
        return 0;
    }

    private int GetItemIndexFromID(int theID)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].Id == theID)
            {
                return i;
            }
        }
        return -1;
    }

    public void AddItemWithObject(Item theObject)
    {
        int index = GetItemIndexFromID(theObject.Id);
        if (index == -1)
            inventory.Add(theObject);
        else
        {
            AddItemWithID(theObject.Id, theObject.Quantity);
        }
    }

    private void AddItemWithID(int theID, int theQuantity)
    {
        if (GetNumberFromID(theID) < _maximumQuantity)
        {
            int index = GetItemIndexFromID(theID);
            if (index > -1)
            {
                Item i = new Item(inventory[index].Id, inventory[index].Name, Mathf.Clamp(inventory[index].Quantity + theQuantity, 0, _maximumQuantity));
                inventory[index] = i;
            }
            else
                print("cannot add item, no corresponding Item");
        }
    }

    private void RemoveItemWithID(int theID, int theQuantity)
    {
        if (GetNumberFromID(theID) >= theQuantity)
        {
            int index = GetItemIndexFromID(theID);
            Item i = new Item(inventory[index].Id, inventory[index].Name, Mathf.Clamp(inventory[index].Quantity - theQuantity, 0, _maximumQuantity));
            inventory[index] = i;
        }
        else
        {
            print("cannot remove item, not enough quantity");
        }
    }
}
