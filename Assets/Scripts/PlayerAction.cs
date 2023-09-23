using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private PlayerInput playerInput;
    private Camera worldCam;

    public Gun gun;
    public LayerMask layerMask;
    public float speed = 5f;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        worldCam = Camera.main;
    }

    private void FixedUpdate()
    {
        PlayerMove();
        PlayerRotate();
    }

    private void Update()
    {
        if (playerInput.fire) 
        {
            gun.Fire();
        }
    }

    private void PlayerMove()
    {

        Vector3 position = playerRigidbody.position;
        position += playerInput.direction * speed * Time.deltaTime;
        playerRigidbody.MovePosition(position);
    }

    private void PlayerRotate()
    {
        var ray = worldCam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hitInfo, 100f, layerMask) ) 
        { 
            var lookPoint = hitInfo.point;
            lookPoint.y = transform.position.y;

            var look = lookPoint - playerRigidbody.position;
            playerRigidbody.MoveRotation(Quaternion.LookRotation(look.normalized));
        }
    }
}
