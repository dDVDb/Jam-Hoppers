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
 
    Item _itemToEat;
    Bottle _bottleToFill;
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
    }

    public void LeaveItem()
    {
        if (!_canLeave)
            return;

        _canLeave = false;
        var i = Inventory.Instance.Fruits[0];
        _bottleToFill?.AddItem(i);
        Inventory.Instance.RemoveItem(i);
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
            _bottleToFill = b;
            b._display.SetActive(true);
            b.UpdateCountText();
            _canLeave = true;
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
            _bottleToFill = null;
            _canLeave = false;
           
        }
    }
}
