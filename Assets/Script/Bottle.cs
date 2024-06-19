using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField]
    int maxItems = 5;

    [SerializeField]
    List<Item> _items;

    [field:SerializeField]
    public GameObject _display {  get; private set; }

    [SerializeField]
    TextMeshProUGUI _countText;

    public bool IsFull {  get; private set; }


    [SerializeField]
    Sprite FullSprite;

    private void Awake()
    {
        _items = new List<Item>();
    }

    public void AddItem(Item i)
    {
        if (_items.Count >= maxItems)
            return;

        _items.Add(i);

        CheckFull();

        var f = GetComponentInParent<Friend>();

        f.ChooseRandomDialogue(i);

        UpdateCountText();
    }

    void CheckFull()
    {
        IsFull = _items.Count >= maxItems;
        
        if(IsFull)
            GetComponent<SpriteRenderer>().sprite = FullSprite;
    }

    public void UpdateCountText()
    {
        _countText.SetText($"{_items.Count}/{maxItems}");
    }

}
