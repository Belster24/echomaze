using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Controller : MonoBehaviour
{
    [Header("Controller settings")]
    [SerializeField] GameObject Player;
    [SerializeField] float moveSpeed; // The speed at which the character moves
    private Rigidbody2D rb; // Reference to the character's Rigidbody2D component
    [Header("Echo Feature Settings")]
    [SerializeField] float echoRayDistance;
    [SerializeField] bool directionalEcho;
    [SerializeField] bool circularEcho;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Light2D playerLightCircle;
    [SerializeField] Light2D playerLightDirectional;
    [SerializeField] float lightTime;
    int lockCounter;
    bool canShootRay;
    [SerializeField] Light2D doorLight;


    [SerializeField] CircleGenerator circleGenerator;

    private void Start()
    {
        canShootRay = true ;
        lockCounter = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        DrawRay();

        if (Input.GetKeyDown(KeyCode.Space)&& canShootRay)
        {
            circleGenerator.AnimateCircles();
            canShootRay = false;
            if (circularEcho)
            {
                playerLightCircle.falloffIntensity = 0f;
                StartCoroutine(EnableLight());
                RaycastHit2D hit = Physics2D.CircleCast(transform.position, echoRayDistance, transform.right, 0f, layerMask); // Shoot the circle cast
                if (hit.collider != null)
                {

                    if (hit.collider.gameObject.CompareTag("lock"))
                    {
                        lockCounter++;
                        Destroy(hit.collider.gameObject);
                        if (lockCounter == 2)
                        {
                            doorLight.color = Color.green;
                        }


                    }

                    else if (hit.collider.gameObject.CompareTag("door"))
                    {
                        if (lockCounter == 2)
                        {
                            Destroy(hit.collider.gameObject);
                        }

                    }




                }

            }


            else if (directionalEcho)
            {
               
                StartCoroutine(EnableLight());
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, echoRayDistance, layerMask); // Shoot the circle cast
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.CompareTag("lock"))
                    {
                        lockCounter++;
                        Destroy(hit.collider.gameObject);
                        if (lockCounter == 2)
                        {
                            doorLight.color = Color.green;
                        }


                    }

                    else if (hit.collider.gameObject.CompareTag("door")) 
                    {
                        if (lockCounter == 2)
                        {
                          Destroy(hit.collider.gameObject); 
                        }

                    }


                    

                }
            }

           


        }
        
    }

    private void FixedUpdate()
    {
        // Get input from the keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Set the character's velocity based on the input
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        movement.Normalize();
        rb.velocity = movement * moveSpeed;


        // Clamp the character's velocity so they can't move faster diagonally
        //rb.velocity = Vector2.ClampMagnitude(rb.velocity, moveSpeed);

        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }


    IEnumerator EnableLight()
    {
        GetComponent<AudioSource>().Play();
        if (circularEcho)
            playerLightCircle.gameObject.SetActive(true);
        else if(directionalEcho)
            playerLightDirectional.gameObject.SetActive(true);
        yield return new WaitForSeconds(lightTime);
        if (circularEcho)
            playerLightCircle.gameObject.SetActive(false);
        else if (directionalEcho)
            playerLightDirectional.gameObject.SetActive(false);
        canShootRay = true;
    }

    void DrawRay()
    {
        Debug.DrawRay(transform.position, transform.right * echoRayDistance, Color.green);

    }


    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;    
    //    Gizmos.DrawSphere(transform.position,echoRayDistance);
    //}
}
