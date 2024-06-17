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
}
