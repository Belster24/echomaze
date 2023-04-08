using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector2 offset;

    private void Update()
    {
        transform.rotation= new Quaternion(0,0,0,0);    
    }
}