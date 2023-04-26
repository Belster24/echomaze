using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

public class EchoLocation : MonoBehaviour
{
    public int ID;
    Rigidbody2D rigidbody;
    public LineRenderer line;
    private bool hasLine = true;
    [SerializeField] float forceMagnitude;
    [SerializeField] float shrinkRate;
    [SerializeField] public float speed;
    [SerializeField] float speedDecrease;
    public float newThickness;
    public EchoLocation previousDot;
    public EchoLocation nextDot;

    int collisionCount;
    private void Start()
    {
  
        line = GetComponent<LineRenderer>();
        
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(-transform.up * speed, ForceMode2D.Impulse);

    }

    private void Update()
    {
        Vector3 newScale = transform.localScale;
        newScale -= Vector3.one * shrinkRate * Time.deltaTime;
        transform.localScale = newScale;
        
        if (previousDot != null && hasLine)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, previousDot.transform.position);
            newThickness = newScale.x;
            line.SetWidth(newThickness,newThickness);
        }
        
        
        if (newScale.x <= 0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "wall")
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = collision.gameObject.GetComponent<Light2D>().color;
            line.startColor = collision.gameObject.GetComponent<Light2D>().color;
            nextDot!.line.endColor = collision.gameObject.GetComponent<Light2D>().color;
            collision.gameObject.GetComponent<LightFunction>().enableLight();

        } else if (collision.gameObject.tag == "enemy")
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = collision.gameObject.GetComponent<Light2D>().color;
            line.startColor = collision.gameObject.GetComponent<Light2D>().color;
            nextDot!.line.endColor = collision.gameObject.GetComponent<Light2D>().color;
            collision.gameObject.GetComponent<LightFunction>().enableLight();
        } else if (collision.gameObject.tag == "lock")
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = collision.gameObject.GetComponent<Light2D>().color;
            line.startColor = collision.gameObject.GetComponent<Light2D>().color;
            nextDot!.line.endColor = collision.gameObject.GetComponent<Light2D>().color;
            rigidbody.AddForce(-transform.up * speed, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<LightFunction>().enableLight();
        }
    }

    
}
