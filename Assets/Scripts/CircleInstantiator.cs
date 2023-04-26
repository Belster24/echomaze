using UnityEngine;

public class CircleInstantiator : MonoBehaviour
{
    [SerializeField]int numObjects = 12;
    [SerializeField] float radius;
    public GameObject prefab;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Invoking()
    {
        Invoke("circle", 0f);
        Invoke("circle", 0.4f);
        Invoke("circle", 0.8f);
    }

    void circle()
    {
        audioSource.Play();
        Vector3 center = transform.position;
        for (int i = 0; i < numObjects; i++)
        {
            int a = i * 30;
            Vector3 pos = RandomCircle(center, radius, a);
            GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
            Vector2 dir = transform.position - pos;
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