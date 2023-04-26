using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float waitTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,waitTime);
    }

  
}
