using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMeele : MonoBehaviour
{
   public float Chillspeed;
   public float Angryspeed;
   public float Backspeed;
   private float leftoright;
   private float Attack;
   public int positionOfPatrol;
   public Transform point;
   bool moveingRight;
   bool moveingUp;

   Transform player;
   public float stoppingDistance;
   [Header("Player Animation Settings")]
   public Animator animator;

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
       
       if(point == null){
            Angry();
       }

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
       }
       else if (angry == true)
       {
            Angry();
       }
       else if (goBack == true)
       {
            Goback();
       }
   }

   void Chill()
   {
        
       if (transform.position.x > point.position.x + positionOfPatrol)
       {
            moveingRight = false;
            leftoright = 1;

       }
       else if (transform.position.x < point.position.x - positionOfPatrol)
       {
            moveingRight = true;
            leftoright = -1;
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

   }

   
   
   
   
   void Goback()
   {
     transform.position = Vector2.MoveTowards(transform.position, point.position, Backspeed * Time.deltaTime);
   }


   
}
