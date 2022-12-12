using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    private float _randX;
    private Vector2 _whereToSpawn;
    [SerializeField] private float spawnRate = 15f;
    private float _nextSpawn = 0.0f;
    
    void Update()
    {
        if(Time.time > _nextSpawn)
        {
            _nextSpawn = Time.time + spawnRate;
            _randX = Random.Range(-30f, 130f);
            _whereToSpawn = new Vector2(_randX, transform.position.y);
            Instantiate(obj, _whereToSpawn, Quaternion.identity);
        }
    }
}
