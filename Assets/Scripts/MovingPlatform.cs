using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private float radius = 2f, angularSpeed = 2f;
    private float positionX, positionY, angle = 0f;

    public void Update()
    {
        positionX = center.position.x + Mathf.Cos(angle) * radius;
        positionY = center.position.y + Mathf.Sin(angle) * radius;
        transform.position = new Vector2(positionX, positionY);
        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360f)
        {
            angle = 0f;
        }

    }
}
