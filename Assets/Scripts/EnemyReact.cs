using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReact : MonoBehaviour
{

    public Vector2 startPoint;
    [SerializeField] Vector3 posMoveEnemy;
    [SerializeField] float moveSpeed;
    public bool toPlayer = false;
    public Vector2 whenHit;

    private void Start()
    {
        startPoint = transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, posMoveEnemy, moveSpeed * Time.deltaTime);

        if (toPlayer)
        {
            posMoveEnemy = GameObject.FindGameObjectWithTag("Player").transform.position;

        }
        else
        {
            posMoveEnemy = startPoint;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Au");

        whenHit = GameObject.FindGameObjectWithTag("Player").transform.position;

        StartCoroutine(enable());

    }

    IEnumerator enable()
    {
        //  gameObject.GetComponent<Shape>().settings.fillColor2 = GetComponent<Light2D>().color;
        toPlayer = true;
        yield return new WaitForSeconds(2f);
        toPlayer = false;
    }

}
