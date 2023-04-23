using UnityEngine;

public class CircleInstantiator : MonoBehaviour
{
    int numObjects = 12;
    public GameObject prefab;
    public void Invoking()
    {
        Invoke("circle", 0f);
        Invoke("circle", 0.4f);
        Invoke("circle", 0.8f);
    }

    void circle()
    {
        Vector3 center = transform.position;
        for (int i = 0; i < numObjects; i++)
        {
            int a = i * 30;
            Vector3 pos = RandomCircle(center, 1.0f, a);
            GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
            Vector2 dir = transform.position - pos;
            obj.transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
        }
    }
    Vector3 RandomCircle(Vector3 center, float radius, int a)
    {
        Debug.Log(a);
        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }




}