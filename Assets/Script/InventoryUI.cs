using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [field: SerializeField]
    public Transform _fruitPage { get; private set; }
    [field: SerializeField]
    public Transform _sugarPage { get; private set; }
    [field: SerializeField]
    public Transform _peppersPage { get; private set; }
    [field: SerializeField]
    public Transform _spicePage { get; private set; }
    [field: SerializeField]
    public Transform _saltPage { get; private set; }

    [field:SerializeField]
    public GameObject Prefab {  get; private set; }

}
