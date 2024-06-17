using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [field:SerializeField]
    public List<Item> Fruits {  get; private set; }

    [field: SerializeField]
    public List<Item> Sugar { get; private set; }

    [field: SerializeField]
    public List<Item> Peppers { get; private set; }
    
    [field: SerializeField]
    public List<Item> Spice { get; private set; }

    [field: SerializeField]
    public List<Item> Salt { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this) 
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    public void AddItem(Item item)
    {
        switch(item._itemType)
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

    public void RemoveItem(Item item)
    {
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
    }
}
