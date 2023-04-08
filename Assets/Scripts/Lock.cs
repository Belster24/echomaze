using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class Lock : MonoBehaviour
{
    [SerializeField] float lightTime;
    [SerializeField] float rayDistance;
    [SerializeField]float currentTime;
    [SerializeField]LayerMask layerMask;
    Light2D light;  
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > lightTime)
        {
          
            StartCoroutine(EnableLight());
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, rayDistance, transform.right, 0f, layerMask); //
            if (hit.collider != null)
            {

                //Debug.Log(" hit object: " + hit.collider.name);


            }
        }
    }

    IEnumerator EnableLight()
    {
        
        light.enabled = true;
        yield return new WaitForSeconds(lightTime); 
        light.enabled = false;
        currentTime = 0;


    }
}
