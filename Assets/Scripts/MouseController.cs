using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 targetPos;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = transform.position.z; // ensure the target position has the same z-coordinate as the player
            Vector3 direction = (targetPos - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
            
        }

       
    }
}
