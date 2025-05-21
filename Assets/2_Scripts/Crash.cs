using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("오 내머리야");
            SceneManager.LoadScene("0");
        }
    }
}