using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    FRUIT,
    SUGAR,
    PEPPERS,
    SPICE,
    SALT
}

public class Item : MonoBehaviour
{
    [field:SerializeField]
    public GameObject _display {  get; private set; }

    [field: SerializeField]
    public ItemType _itemType {  get; private set; }


    public static bool operator ==(Item a, Item b)
    {
        return (a.gameObject.name == b.gameObject.name && a._itemType == b._itemType);
    }
    public static bool operator !=(Item a, Item b)
    {
        return (a.gameObject.name != b.gameObject.name || a._itemType != b._itemType);
    }
}
