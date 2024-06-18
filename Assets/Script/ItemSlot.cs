using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    Item _referenceItem;

    [SerializeField]
    TextMeshProUGUI _name;
    public Item ReferenceItem { get { return _referenceItem; } set { _referenceItem = value; } }

    [field:SerializeField]
    public Button Button { get; private set; }

}
