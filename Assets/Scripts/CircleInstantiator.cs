using System.Collections.Generic;
using UnityEngine;

public class CircleInstantiator : MonoBehaviour
{
    [SerializeField]int numObjects = 24;
    public int numberOfCircles = 3;
    public float circleDelay = 0.4f;
    [SerializeField] float radius;
    [SerializeField] float dotSpeed = 10f;
    [SerializeField] float speedDecrease = 1f;

    public GameObject prefab;
    AudioSource audioSource;
    List<EchoLocation> dots = new List<EchoLocation>();
    EchoLocation previousDotListed = null;
    


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Invoking()
    {
        if (audioSource!= null)
            audioSource.Play();
        float _circleDelay = 0;
        for (int i = 0; i < numberOfCircles; i++)
        {
            Invoke("circle", _circleDelay);
            _circleDelay += circleDelay;
        }
        
    }

    void circle()
    {
        Vector3 center = transform.position;

        previousDotListed = null;
        for (int i = 0; i < numObjects; i++)
            dots.Add(null); // fill list with nulls
        
        for (int i = 0; i < numObjects; i++)
        {
            int a = i * 30;
            Vector3 pos = RandomCircle(center, radius, a);
            GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
            
            dots.Add(obj.GetComponent<EchoLocation>());
            obj.GetComponent<EchoLocation>().ID = i;
            if (previousDotListed != null)
            {
                previousDotListed.nextDot = obj.GetComponent<EchoLocation>();
                obj.GetComponent<EchoLocation>().previousDot = previousDotListed;

            }
            previousDotListed = obj.GetComponent<EchoLocation>();
            if (i == numObjects-1)
                obj.GetComponent<EchoLocation>().nextDot = dots[0];
            
            Vector2 dir = transform.position - pos;

            obj.GetComponent<EchoLocation>().speed = dotSpeed;
            obj.GetComponent<EchoLocation>().speedDecrease = speedDecrease;


            obj.transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
        }

    }
    Vector3 RandomCircle(Vector3 center, float radius, int a)
    {
        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }




}