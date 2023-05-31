using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    private Vector3 dragStartPos, dragEndPos, dragDirection;
    Rigidbody2D rb;
    [SerializeField] private float maxDragDistance;
    [SerializeField] private float power;
    [Header("MouseMovement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    Vector3 targetPos;
    [Header("EchoSetting")]
    [SerializeField] private GameObject echoPrefab;
    [SerializeField]int numProjectiles;
    [SerializeField]float spreadAngle;
    [SerializeField] GameObject indicator;
    private LineRenderer lineRenderer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;

    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if(gameObject.GetComponent<HighScoreTime>() != null)
                GetComponent<HighScoreTime>().startTimer = true;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, mousePos, moveSpeed * Time.deltaTime);
            Vector3 direction = (mousePos - transform.position).normalized;
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        }
    }
    private void OnMouseDown()
    {
        lineRenderer.enabled = true;
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragStartPos.z = 0f;
        }
    }

    private void OnMouseDrag()
    {
        dragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragEndPos.z = 0f;
        dragDirection = (dragStartPos - dragEndPos).normalized;
        float distance = Vector2.Distance(dragStartPos, dragEndPos);
        if (distance > maxDragDistance)
        {
            distance = maxDragDistance;
            dragEndPos = dragStartPos - dragDirection * distance;
        }
        float angle = Mathf.Atan2(dragDirection.y, dragDirection.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Debug.DrawLine(dragStartPos, dragEndPos);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, dragEndPos);
    }

    private void OnMouseUp()
    {
        lineRenderer.enabled = false;
        Invoke("ShootingWave", 0f);
        Invoke("ShootingWave", 0.3f);
        Invoke("ShootingWave", 0.8f);


    }

    void ShootingWave()
    {
        float force = power * Vector2.Distance(dragStartPos, dragEndPos);
        Vector2 spawnPos = transform.position + (Vector3)dragDirection * 0.5f;
        float angleStep = spreadAngle / (numProjectiles - 1);
        float startAngle = -spreadAngle / 2f;
        for (int i = 0; i < numProjectiles; i++)
        {
            float angle = startAngle + i * angleStep;
            Vector2 direction = Quaternion.Euler(0f, 0f, angle) * dragDirection;

            GameObject echoBall = Instantiate(echoPrefab, spawnPos, Quaternion.identity);
            echoBall.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
        }



    }
}
