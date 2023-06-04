using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRange : MonoBehaviour
{
   public float Chillspeed;
   public float Angryspeed;
   public float Backspeed;
   public float leftoright;
   public Transform FirePoint;
   public GameObject FireObject;
   public float AttackCollDawn;
   public float Attack;
   public float AttackCollDawnForUnity;
   [Header("Player Animation Settings")]
   public Animator animator;
   public int positionOfPatrol;
   public Transform point;
   bool moveingRight;
   bool moveingUp;


   Transform player;
   public float stoppingDistance;

   bool chill = false;
   bool angry = false;
   bool goBack = false;

   void Start()
   {
       player = GameObject.FindGameObjectWithTag("Player").transform;
   }

   void Update()
   {    
       animator.SetFloat("LeftOrRight",leftoright);
       animator.SetFloat("Attack",Attack);
       if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false )
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
            Attack = 0;
       }
       else if (angry == true)
       {
            Angry();
            Attack = 1;

       }
       else if (goBack == true)
       {
            Goback();
            Attack = 0;
       }
       AttackCollDawnForUnity -= Time.deltaTime;
   }

   void Chill()
   {
       Attack = 0;
       if (transform.position.x > point.position.x + positionOfPatrol)
       {
            leftoright = 1;

            moveingRight = false;

       }
       else if (transform.position.x < point.position.x - positionOfPatrol)
       {
            moveingRight = true;

       }
       if(transform.position.y > point.position.y + positionOfPatrol)
       {
              moveingUp = false;
       }
       else if (transform.position.y < point.position.y - positionOfPatrol)
       {
              moveingUp = true;
       }
       
       

       if (moveingRight)
       {    
            leftoright = -1;

            if(moveingUp)
            {
                transform.position = new Vector2(transform.position.x + Chillspeed * Time.deltaTime, transform.position.y + Chillspeed * Time.deltaTime);

            }
            else
            {
                transform.position = new Vector2(transform.position.x + Chillspeed * Time.deltaTime, transform.position.y - Chillspeed * Time.deltaTime);

            }
       }
       else
       {
            leftoright = 1;
            if(moveingUp)
            {
                transform.position = new Vector2(transform.position.x - Chillspeed * Time.deltaTime, transform.position.y + Chillspeed * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(transform.position.x - Chillspeed * Time.deltaTime, transform.position.y - Chillspeed * Time.deltaTime);

            }
       }   
   }
    

   void Angry()
   {
     transform.position = Vector2.MoveTowards(transform.position, player.position, Angryspeed * Time.deltaTime);
     if (AttackCollDawnForUnity <= 0 ){
        Instantiate(FireObject, FirePoint.position, FirePoint.rotation);
        AttackCollDawnForUnity = AttackCollDawn;
     }
     else{
        AttackCollDawnForUnity -= Time.deltaTime;
     }
   }

   void Goback()
   {

     transform.position = Vector2.MoveTowards(transform.position, point.position, Backspeed * Time.deltaTime);
   }

   
}
