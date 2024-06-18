using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    [field:SerializeField]
    public List<Transform> TeleportPoints {  get; private set; }


    [field:SerializeField]
    public GameObject Display { get; private set; }


    [SerializeField]
    GameObject TeleportUI;

    [SerializeField]
    List<GameObject> TeleportButtons;

    [SerializeField]
    Transform TeleportButtonPage;

    [SerializeField]
    GameObject TeleportButtonPrefab;

    PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();    
    }
    private void Start()
    {
        foreach (Transform t in TeleportPoints)
        {
            var b = Instantiate(TeleportButtonPrefab, TeleportButtonPage);

            b.GetComponent<Button>().onClick.AddListener(() => Teleport(t));

            TeleportButtons.Add(b); 

            b.SetActive(false);
        }
    }

    public void StartTeleport()
    {
        Debug.Log("START TELEPORT");

        TeleportUI.SetActive(true);

        foreach(var t in TeleportButtons)
        {
            t.SetActive(true);
        }
    }

    public void Teleport(Transform t)
    {
        TeleportUI.SetActive(false);

        foreach (var tr in TeleportButtons)
        {
            tr.SetActive(false);
        }

        playerController.transform.position = t.position;
    }
}
