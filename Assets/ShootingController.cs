using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ShootingController : MonoBehaviour
{
    public Transform bowString;
    public Transform directionPointer;
    public float radiusMax = 1f;
    public float radiusMin = 0.5f;
    public bool followRotation;

    private Transform cursorPosition;
    private Transform playerTransform;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        playerTransform = transform;
    }


    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = _camera.ScreenToWorldPoint(mousePos);
        mousePos.z = 0f;

        float distance = Vector3.Distance(playerTransform.position, mousePos);
        float clampedDistance = Mathf.Clamp(distance, radiusMin, radiusMax);


        // Calculate the position of the direction pointer
        Vector3 direction = (mousePos - playerTransform.position).normalized;
        Vector3 mousePositionConstrained = playerTransform.position + direction * clampedDistance;

        // Set the position of the direction pointer
        bowString.position = mousePositionConstrained;

        // Draw a line from the direction pointer to the player
        Debug.DrawLine(bowString.position, playerTransform.position, Color.green);

        // Create another object on the other side of the player
        Vector3 directionPointerPos = playerTransform.position - direction * clampedDistance;
        directionPointer.position = directionPointerPos;
        
        
        if (followRotation)
        {
            // directionPointer.LookAt(playerTransform);
            // bowString.LookAt(playerTransform);
            // Vector3 bowStringRotation = new Vector3(0f, 0f, bowString.rotation.z);
            // bowString.rotation = Quaternion.Euler(bowStringRotation);
        }
        
        Debug.DrawLine(directionPointerPos, playerTransform.position, Color.green);
    }
}
