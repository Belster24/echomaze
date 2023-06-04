using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EchoLocation : MonoBehaviour
{
    public int ID;
    Rigidbody2D rigidbody;
    public LineRenderer line;
    private bool hasLine = true;
    [SerializeField] float forceMagnitude;
    [SerializeField] float shrinkRate;
    [SerializeField] public float speed;
    [SerializeField] public float speedDecrease;
    public float newThickness;
    EchoLocation DotToConnect;
    [SerializeField]int prefabID = 0;
    public static int nextPrefabID = 0;
    LineRenderer lineRenderer;
   

    private void Start()
    {
        
      
        prefabID = nextPrefabID;
        nextPrefabID++;
        line = GetComponent<LineRenderer>();
   

        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(-transform.up * speed, ForceMode2D.Impulse);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        FindNeighboringEchoPrefabs();
    }

    [System.Obsolete]
    private void Update()
    {
        Vector3 newScale = transform.localScale;
        newScale -= Vector3.one * shrinkRate * Time.deltaTime;
        transform.localScale = newScale;
        line.SetWidth(newScale.x, newScale.x);
        if (newScale.x <= 0f)
        {
            Destroy(gameObject);
        }

        if (prefabID % 10 != 0)
        {
            UpdateLineRenderer();
        }
        lineRenderer.SetWidth(newScale.x, newScale.x);

    }

    private void UpdateLineRenderer()
    {
        lineRenderer.SetPosition(0, transform.position); // First position is the echo prefab's position
        lineRenderer.SetPosition(1, GetNearestNeighborPosition(DotToConnect)); // Second position is the left neighbor's position
    }
    private Vector3 GetNearestNeighborPosition(EchoLocation neighbor)
    {
        if (neighbor != null)
        {
            return neighbor.transform.position;
        }

        return transform.position; // If no neighbor found, return the echo prefab's position
    }

    private void FindNeighboringEchoPrefabs()
    {
        EchoLocation[] allEchoPrefabs = FindObjectsOfType<EchoLocation>();
        

        foreach (EchoLocation neighborEcho in allEchoPrefabs)
        {
            if (neighborEcho.prefabID == prefabID - 1)
            {
                DotToConnect = neighborEcho;
            }

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ContactPoint2D contact = collision.contacts[collisionCount];
        //Vector3 pos = contact.point;
        //Instantiate(collisionLight, pos, Quaternion.identity);
        //collisionCount++;



        if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("lock"))
        {
            Color collisionColor = collision.gameObject.GetComponent<Light2D>().color;
            gameObject.GetComponentInChildren<SpriteRenderer>().color = collisionColor;
            line.startColor = collisionColor;
            line.endColor = collisionColor;
            collision.gameObject.GetComponent<LightFunction>().enableLight();

            if (collision.gameObject.CompareTag("lock"))
            {
                rigidbody.AddForce(-transform.up * speed, ForceMode2D.Impulse);
            }
        }

        else if (collision.gameObject.CompareTag("door"))
        {

            gameObject.GetComponent<SpriteRenderer>().color = 
                collision.gameObject.GetComponent<Light2D>().color;

 
        }


    }






}
