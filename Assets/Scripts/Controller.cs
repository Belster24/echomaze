using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
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
    [SerializeField] CircleInstantiator circleInstantiator; 
    bool canShootRay;
    [SerializeField] Light2D doorLight;


    private void Start()
    {
        canShootRay = true ;
        rb = GetComponent<Rigidbody2D>();
        circleInstantiator = GetComponentInParent<CircleInstantiator>();
    }

    private void Update()
    {
        DrawRay();

        if (Input.GetKeyDown(KeyCode.Space)&& canShootRay)
        {
            canShootRay = false;
            StartCoroutine(StartEcho());
            
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

    }


    IEnumerator StartEcho()
    {
        circleInstantiator.Invoking();
        yield return new WaitForSeconds(lightTime);
        canShootRay = true;
        //if(circularEcho)
        //    playerLightCircle.gameObject.SetActive(true);
        //else if(directionalEcho)
        //    playerLightDirectional.gameObject.SetActive(true);
        //yield return new WaitForSeconds(lightTime);
        //if (circularEcho)
        //    playerLightCircle.gameObject.SetActive(false);
        //else if (directionalEcho)
        //    playerLightDirectional.gameObject.SetActive(false);
        //canShootRay = true;
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
