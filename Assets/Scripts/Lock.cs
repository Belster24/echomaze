using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject Player;

    private void Start()
    {
        InvokeRepeating("PlayAudio", 1f, 1f);
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        float distance = Vector2.Distance(transform.position, Player.transform.position);
        audioSource.volume = Mathf.Clamp(1.0f - (distance / 20.0f), 0.0f, 1.0f);
    }
    void PlayAudio()
    {
        audioSource.Play();
    }


    //[SerializeField] float lightTime;
    //[SerializeField] float rayDistance;
    //[SerializeField]float currentTime;
    //[SerializeField]LayerMask layerMask;
    //[SerializeField] bool lightFeature;
    //Light2D light;
    //[SerializeField] AudioSource audioSource;
    //[SerializeField] GameObject Player;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    light = GetComponent<Light2D>();    
    //    audioSource = GetComponent<AudioSource>();
    //    Player = GameObject.FindGameObjectWithTag("Player");
    //    InvokeRepeating("PlayAudio",1f,1f);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Vector2 objectVector = Player.transform.position - transform.position;
    //    float dot = Vector2.Dot(objectVector, Vector2.up);
    //    if (dot > 1)
    //    {
    //        audioSource.panStereo = 1f;
    //    }
    //    else if (dot < -1)
    //    {
    //        audioSource.panStereo = -1f;
    //    }
    //    else
    //    {

    //        audioSource.panStereo = 0f;
    //    }
    //    currentTime += Time.deltaTime;
    //    if (currentTime > lightTime)
    //    {
    //        if(lightFeature)
    //            StartCoroutine(EnableLight());
    //        RaycastHit2D hit = Physics2D.CircleCast(transform.position, rayDistance, transform.right, 0f, layerMask); //
    //        if (hit.collider != null)
    //        {

    //            //Debug.Log(" hit object: " + hit.collider.name);


    //        }
    //    }
    //    float distance = Vector2.Distance(transform.position, Player.transform.position);
    //    audioSource.volume = Mathf.Clamp(1.0f - (distance / 20.0f), 0.0f, 1.0f);


    //}

    //void PlayAudio()
    //{
    //    audioSource.Play();
    //}

    //IEnumerator EnableLight()
    //{

    //    light.enabled = true;
    //    yield return new WaitForSeconds(lightTime); 
    //    light.enabled = false;
    //    currentTime = 0;


    //}
}
