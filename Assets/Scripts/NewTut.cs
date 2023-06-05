using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewTut : MonoBehaviour
{
    [SerializeField] BellAndDoor bd;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "door")
        {
            
            PlayerPrefs.SetInt("tutorial", 1);
            SceneManager.LoadScene("level_1");
        }
        if (collision.gameObject.tag == "lock")
        {
            Destroy(collision.gameObject);
            bd.count++;
        }
    }
}
