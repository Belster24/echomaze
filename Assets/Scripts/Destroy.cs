using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destroy : MonoBehaviour
{
    [SerializeField]public bool justForLight = true;
    public float waitTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,waitTime);
    }

    private void OnDestroy()
    {
        justForLight = true;   
    }






}
