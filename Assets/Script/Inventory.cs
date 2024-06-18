using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [field: SerializeField]
    public List<Item> Fruits { get; private set; }

    [field: SerializeField]
    public List<Item> Sugar { get; private set; }

    [field: SerializeField]
    public List<Item> Peppers { get; private set; }

    [field: SerializeField]
    public List<Item> Spice { get; private set; }

    [field: SerializeField]
    public List<Item> Salt { get; private set; }

    [field: SerializeField]
    public InventoryUI InventoryUI { get; private set; }


    [field: SerializeField]
    public GameObject InventoryPage { get; private set; }

    PlayerController playerController;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);

        playerController = FindObjectOfType<PlayerController>();
    }

    public void AddItem(Item item)
    {
        switch (item._itemType)
        {
            case ItemType.FRUIT:
                Fruits.Add(item);
                break;
            case ItemType.SUGAR:
                Sugar.Add(item);
                break;
            case ItemType.PEPPERS:
                Peppers.Add(item);
                break;
            case ItemType.SPICE:
                Spice.Add(item);
                break;
            case ItemType.SALT:
                Salt.Add(item);
                break;
        }
    }

    public void RemoveItem(Item item,ItemSlot slot)
    {

        Debug.Log("ITEM REMOVE");

        switch (item._itemType)
        {
            case ItemType.FRUIT:
                Fruits.Remove(item);
                break;
            case ItemType.SUGAR:
                Sugar.Remove(item);
                break;
            case ItemType.PEPPERS:
                Peppers.Remove(item);
                break;
            case ItemType.SPICE:
                Spice.Remove(item);
                break;
            case ItemType.SALT:
                Salt.Remove(item);
                break;

        }
        
        playerController?.BottleToFill?.AddItem(item);
        slot.Button.onClick.RemoveAllListeners();
        slot.gameObject.SetActive(false);
    }

    public void CreateSlot(Item item)
    {
        var s = new ItemSlot();
        
        switch (item._itemType)
        {
            case ItemType.FRUIT:
                s = Instantiate(InventoryUI.Prefab,InventoryUI._fruitPage).GetComponent<ItemSlot>();
                break;
            case ItemType.SUGAR:
                s = Instantiate(InventoryUI.Prefab, InventoryUI._sugarPage).GetComponent<ItemSlot>();
                break;
            case ItemType.PEPPERS:
                s = Instantiate(InventoryUI.Prefab, InventoryUI._peppersPage).GetComponent<ItemSlot>();
                break;
            case ItemType.SPICE:
                s = Instantiate(InventoryUI.Prefab, InventoryUI._spicePage).GetComponent<ItemSlot>();
                break;
            case ItemType.SALT:
                s = Instantiate(InventoryUI.Prefab, InventoryUI._saltPage).GetComponent<ItemSlot>();
                break;
        }

        s.ReferenceItem = item;
        s.Button.onClick.AddListener(() => RemoveItem(item,s));
    }
}
