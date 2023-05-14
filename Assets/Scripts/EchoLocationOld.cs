using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class EchoLocationOld : MonoBehaviour
{

    [SerializeField] float shrinkRate;
    int collisionCount;
  

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

        }
        else if (collision.gameObject.tag == "enemy")
        {

            gameObject.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<Light2D>().color;
            collision.gameObject.GetComponent<LightFunction>().enableLight();
        }
        else if (collision.gameObject.tag == "lock")
        {

            gameObject.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<Light2D>().color;
            collision.gameObject.GetComponent<LightFunction>().enableLight();
        }
    }
}
