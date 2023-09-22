using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraScroll : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;
    private float yOffset = 2f;

    // Update is called once per frame
    void Update()
    {
        FollowCamera();
        LookCharacter();
    }

    private void FollowCamera()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, Time.deltaTime * 5);
    }

    private void LookCharacter()
    {
        Vector3 v = player.position;
        v.y += yOffset;

        Vector3 dir = v - (player.position + offset);
        Quaternion rot = Quaternion.LookRotation(dir.normalized);

        transform.rotation = rot;
    }
}
