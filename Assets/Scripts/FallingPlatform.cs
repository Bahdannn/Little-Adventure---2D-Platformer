using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D _rb;

    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Invoke("FallOfPlatform", 0.7f);
            Destroy(gameObject, 4f);
        }
    }

    private void FallOfPlatform()
    {
        _rb.isKinematic = false;
    }
}
