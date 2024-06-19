using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed;

    Rigidbody rb;
    Vector3 movement;
    Animator animator;
    bool _canEat;
    bool _canLeave;
    bool _canTeleport;
 
    Item _itemToEat;
    Teleporter _activeTeleporter;

    [SerializeField]
    public Bottle BottleToFill {  get; private set; }
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.z);

        if (Input.GetKeyDown(KeyCode.E))
            Eat();

        if (Input.GetKeyDown(KeyCode.L))
            LeaveItem();

        if(Input.GetKeyDown(KeyCode.T))
            Teleport();
         
    }
    void Eat()
    {
        if (!_canEat)
            return;

        _canEat = false;
        animator.SetTrigger("Eat");
    }
    public void EatCallback()
    {
        _itemToEat?.gameObject.SetActive(false);
        Inventory.Instance.AddItem(_itemToEat);
        Inventory.Instance.CreateSlot(_itemToEat);
    }
    public void LeaveItem()
    {
        if (!_canLeave)
            return;

        Inventory.Instance.InventoryPage.SetActive(true);
    }

    public void Teleport()
    {
        if (!_canTeleport) return;

        _activeTeleporter?.StartTeleport();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item"))
        {
            var i = other.GetComponentInParent<Item>();
            i._display.SetActive(true);
            _itemToEat = i;
            _canEat = true;
        }

        if (other.CompareTag("Bottle"))
        {
            var b = other.GetComponentInParent<Bottle>();
            
            if (b.IsFull)
                return;

            BottleToFill = b;
            b._display.SetActive(true);
            b.UpdateCountText();
            _canLeave = true;
        }

        if (other.CompareTag("Teleporter"))
        {
            var t = other.GetComponent<Teleporter>();
            _activeTeleporter = t;
            t.Display.SetActive(true);
            _canTeleport = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            other.GetComponentInParent<Item>()._display.SetActive(false);
            _itemToEat = null;
            _canEat = false;
        }

        if(other.CompareTag("Bottle"))
        {
            var b = other.GetComponentInParent<Bottle>();
            b._display.SetActive(false);
            BottleToFill = null;
            _canLeave = false;
           
        }

        if (other.CompareTag("Teleporter"))
        {
            var t = other.GetComponent<Teleporter>();
            _activeTeleporter = null;
            t.Display.SetActive(false);
            _canTeleport = false;
        }
    }
}
