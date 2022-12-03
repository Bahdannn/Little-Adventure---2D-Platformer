using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float speed;
   public int positionOfPatrol;
   public Transform point;
   public bool movingRight;
   
   public Transform player;
   public float stoppingDistance;

   private bool chill = false;
   private bool angry = false;
   private bool goBack = false;

   public void Start()
   {
      player = GameObject.FindGameObjectWithTag("Player").transform;
   }

   public void Update()
   {
      if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
      {
         chill = true;
      }

      if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
      {
         angry = true;
         chill = false;
         goBack = false;
      }
      
      if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
      {
         goBack = true;
         angry = false;
      }

      if (chill == true)
      {
         Chill();
      }
      else if (angry == true)
      {
         Angry();
      }
      else if (goBack == true)
      {
         GoBack();
      }
   }

   public void Chill()
   {
      if (transform.position.x > point.position.x + positionOfPatrol)
      {
         movingRight = false;
      }
      else if (transform.position.x < point.position.x - positionOfPatrol)
      {
         movingRight = true;
      }

      if (movingRight)
      {
         transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
      }
      else
      {
         transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

      }
   }

   public void Angry()
   {
      transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
      speed = 4;
   }

   public void GoBack()
   {
      transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);

   }
   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject == Player.Instance.gameObject)
      {
         Player.Instance.GetDamage();
      }
   }
}
