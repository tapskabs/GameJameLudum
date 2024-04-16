using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("You hit" + collision.gameObject.name);
            Destroy(gameObject);
            WinnerScreen();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
    void WinnerScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
