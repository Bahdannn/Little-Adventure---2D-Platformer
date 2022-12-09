using UnityEngine;
using UnityEngine.SceneManagement;


public class Finish : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            SceneManager.LoadScene(0);
        }
    }
}
