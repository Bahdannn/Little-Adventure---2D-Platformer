using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    private float RandX;
    private Vector2 whereToSpawn;
    [SerializeField] private float spawnRate = 2f;
    private float nextSpawn = 0.0f;
    
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            RandX = Random.Range(-23f, 15f);
            whereToSpawn = new Vector2(RandX, transform.position.y);
            Instantiate(obj, whereToSpawn, Quaternion.identity);
        }
    }
}
