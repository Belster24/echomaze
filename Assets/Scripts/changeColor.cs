using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject parent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        gameObject.GetComponent<ParticleSystem>().startColor =
            gameObject.GetComponentInParent<SpriteRenderer>().color;
    }
}
