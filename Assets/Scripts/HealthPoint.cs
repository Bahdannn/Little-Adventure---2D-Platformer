using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GetHealth();
            Destroy(gameObject);
        }
    }
}
