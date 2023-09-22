using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput input;

    public float speed = 5f;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
        input = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        Vector3 movePos = rb.position + input.direction * speed * Time.deltaTime;

        rb.MovePosition(movePos);
    }
}
