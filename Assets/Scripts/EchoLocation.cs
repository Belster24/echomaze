using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EchoLocation : MonoBehaviour
{
    Rigidbody2D rigidbody;  
    [SerializeField] Color32 colorForWall;
    [SerializeField] Color32 colorForEnemy;
    [SerializeField] float forceMagnitude;
    [SerializeField] float shrinkRate;
    int collisionCount;
    private void Start()
    {
  
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(-transform.up * forceMagnitude, ForceMode2D.Impulse);

    }

    private void Update()
    {
        Vector3 newScale = transform.localScale;
        newScale -= Vector3.one * shrinkRate * Time.deltaTime;
        transform.localScale = newScale;
        if (newScale.x <= 0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "wall")
        {
            gameObject.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<Light2D>().color;
            collision.gameObject.GetComponent<LightFunction>().enableLight();

        } else if (collision.gameObject.tag == "enemy")
        {

            gameObject.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<Light2D>().color;
            collision.gameObject.GetComponent<LightFunction>().enableLight();
        }
    }

    
}
