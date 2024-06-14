using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed;

    private PlayerControls playerControls;

    private Rigidbody rb;
    private Vector3 movement_V3;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float x = playerControls.Player.Movement.ReadValue<Vector2>().x;
        float z = playerControls.Player.Movement.ReadValue<Vector2>().y;

        Debug.Log(x + "," + z);
        movement_V3 = new Vector3(x, 0, z).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + movement_V3 * speed*Time.fixedDeltaTime);
    }
}
