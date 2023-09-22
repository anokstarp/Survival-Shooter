using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    public Vector3 direction { get; private set; }

    public bool fire { get; private set; }

    private Animator animator;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        fire = Input.GetButton("Fire1");


        direction = new Vector3(horizontal, 0, vertical);
        if (direction.magnitude > 1) direction = direction.normalized;

        animator.SetFloat("Speed", direction.magnitude);

        Debug.Log(fire);
    }
}
