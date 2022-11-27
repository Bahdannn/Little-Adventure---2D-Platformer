using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForse = 5f;
    
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public bool Grounded = false;
    public Transform GroundCheck;
    public float GroundRadius = 0.2f;
    public LayerMask whatIsGround;
    public Text HpT;

    public static Player Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void Start()
    {
        HpT.text = "Player HP: " + lives;
    }


    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (Input.GetButtonDown("Jump") && Grounded)
            Jump();

        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, whatIsGround);
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
        
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForse, ForceMode2D.Impulse);
    }

    public void GetDamage()
    {
        lives -= 1;
        HpT.text = "Player HP: " + lives;
        Debug.Log(lives);
    }

    public void GetHealth()
    {
        lives += 1;
        HpT.text = "Player HP: " + lives;
        Debug.Log(lives);
    }
}