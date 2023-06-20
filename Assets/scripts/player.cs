using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [Header("Player Moving Settings")]
    public float speed;
    public Rigidbody2D rb;
    private Vector2 move;
    private bool choice;
    public FixedJoystick joystick;
    [Header("Player Attack Settings")]
    public Transform attack_Point;
    public int damage;
    public float AttackCollDawn;
    private float AttackCollDawnForUnity;
    public float attack_range = 0.5f;
    public LayerMask enemyLayers;
    public LayerMask ChestLayers;
    [Header("Player Animation Settings")]
    public Animator animator;



    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            choice = true;
        
        else if (Input.GetKeyDown(KeyCode.J))
            choice = false;

        if (choice)
        {
            move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            move.x = joystick.Horizontal;
            move.y = joystick.Vertical;
        }
        animator.SetFloat("HorizintalMove", move.x);
        animator.SetFloat("VerticalMove", move.y);
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.E))
        {
            interaction();
        }


        if (AttackCollDawnForUnity <= 0)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                AttackCollDawnForUnity = AttackCollDawn;
                animator.SetTrigger("Attack");

            }
        }
        else
        {
            AttackCollDawnForUnity -= Time.deltaTime;
        }
    }
    public void Attack()
    {
        AttackCollDawnForUnity = AttackCollDawn;
        AttackCollDawnForUnity -= Time.deltaTime;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack_Point.position, attack_range, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log(enemy);
                enemy.GetComponent<Enemy>().TakeDamage(damage);
            }

    }   
    public void interaction()
    {
        Debug.Log("ÄÀ");
        Collider2D[] Objects = Physics2D.OverlapCircleAll(attack_Point.position, attack_range, ChestLayers);
            foreach (Collider2D Heal in Objects)
            {
                Debug.Log(Heal);
            }

    }

    void OnDrawGizmosSelected(){
        if (attack_Point == null){
            return;
        }
        Gizmos.DrawWireSphere(attack_Point.position, attack_range);
    }
}