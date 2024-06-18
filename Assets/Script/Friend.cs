using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Friend : MonoBehaviour
{
    [SerializeField] Bottle _bottle;

    [field: Header("ITEMS")]
    [field:SerializeField] public List<Item> LikedItems { get; private set; }
    [field:SerializeField] public List<Item> DislikedItems { get; private set; }
    [field:SerializeField] public List<Item> TabooItems { get; private set; }

    [field:Header("DIALOGUE")]
    [field:SerializeField] public List<string>   LikedDialogue { get; private set; }
    [field: SerializeField] public List<string> DiskedDialogue { get; private set; }
    [field: SerializeField] public List<string> TabooDialogue { get; private set; }

    [SerializeField]
    TextMeshProUGUI dialogueText;
    public void ChooseRandomDialogue(Item i)
    {
        foreach (var item in LikedItems)
        {
            if (item == i)
            {
                var t = LikedDialogue[Random.Range(0, LikedDialogue.Count - 1)];
                StartCoroutine(DisplayWithTime(t));
                return;
            }
        }

        foreach (var item in DislikedItems)
        {
            if (item == i)
            {
                var t = DiskedDialogue[Random.Range(0, DiskedDialogue.Count - 1)];
                StartCoroutine(DisplayWithTime(t));
                return;
            }
        }

        foreach (var item in TabooItems)
        {
            if (item == i)
            {
                var t = TabooDialogue[Random.Range(0, TabooDialogue.Count - 1)];
                StartCoroutine(DisplayWithTime(t));
                return;
            }
        }
    }

   IEnumerator DisplayWithTime(string t)
    {
        dialogueText.gameObject.SetActive(true);
        dialogueText.SetText(t);

        yield return new WaitForSeconds(2);

        dialogueText.gameObject.SetActive(false);
        dialogueText.SetText("");

    }


}
