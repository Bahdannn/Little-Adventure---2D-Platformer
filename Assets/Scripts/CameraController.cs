using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 _pos;

    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        _pos = player.position;
        _pos.z = -10f;
        transform.position = Vector3.Lerp(transform.position, _pos, Time.deltaTime);
    }
}
