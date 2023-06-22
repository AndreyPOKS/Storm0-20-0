using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;

public class AIRange : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float Chillspeed;
    public float Angryspeed;
    public float Backspeed;
    public float leftoright;
    public Transform FirePoint;
    public GameObject FireObject;
    public float AttackCollDawn;
    public float Attack;
    public float AttackCollDawnForUnity;
    public Transform item;
    public Transform Keys;
    [Header("Enemy Animation Settings")]
    public Animator animator;
    public int positionOfPatrol;
    public Transform point;
    bool moveingRight;
    bool moveingUp;
    [Header("Enemy Heatlh Settings")]
    private float randomNumber;
    public int MaxHp;
    public int Hp;
    public Image[] lives;
    private Material MathBlink;
    private Material MathDefault;
    private SpriteRenderer spriteRend;
    public Sprite FullHp;
    public Sprite EmptyHp;
    private Transform player;
    public float stoppingDistance;

   bool chill = false;
   bool angry = false;
   bool goBack = false;

   void Start()
   {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].enabled = false;
        }
        Hp = MaxHp;
        spriteRend = GetComponent<SpriteRenderer>();
        MathBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        MathDefault = spriteRend.material;  
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
        UnSetHealth(Hp);
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
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].enabled = false;
        }
    }
    public void TakeDamage(int damage)
    {

        Hp -= damage;
        spriteRend.material = MathBlink;
        UnSetHealth(Hp);
        Invoke("ResetMaterial", .2f);
        
    }

    public void UnSetHealth(int Hp)
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].enabled = false;
        }
        switch (Hp)
        {
            case >= 60:
                lives[0].sprite = FullHp;
                lives[0].enabled = true;
                break;

            case >= 40:

                lives[1].enabled = true;
                break;

            case >= 20:
                lives[2].enabled = true;
                break;

            case >= 0:
                Die();
                break;

        }
    }
    void ResetMaterial()
    {
        spriteRend.material = MathDefault;
    }
    void Die()
    {
        if (randomNumber >= 1)
        {
            Instantiate(Keys, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(item, transform.position, transform.rotation);
            Destroy(gameObject);
        }


    }

}
