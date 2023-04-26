using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MouseDots : MonoBehaviour
{
  
    [Header("Echo Feature Settings")]
    [SerializeField] float echoRayDistance;
    [SerializeField] bool circularEcho;
    [SerializeField] float lightTime;
    [SerializeField] CircleInstantiator circleInstantiator;
    bool canShootRay;
   


    private void Start()
    {
        canShootRay = true;
        circleInstantiator = GetComponentInParent<CircleInstantiator>();
    }

    private void Update()
    {
        DrawRay();

        if (Input.GetMouseButtonDown(0) && canShootRay)
        {
            canShootRay = false;
            if (circularEcho)
            {
                StartCoroutine(StartEcho());
                

            }

        }

    }

   


    IEnumerator StartEcho()
    {
        circleInstantiator.Invoking();
        yield return new WaitForSeconds(lightTime);
        canShootRay = true;
       
    }

    void DrawRay()
    {
        Debug.DrawRay(transform.position, transform.right * echoRayDistance, Color.green);

    }

}
