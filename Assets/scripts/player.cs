using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector2 move;
    public Transform attack_Point;
    public int damage;
    public float AttackCollDawn;
    private float AttackCollDawnForUnity;
    public float attack_range = 0.5f;
    public LayerMask enemyLayers;
    [Header("Player Animation Settings")]
    public Animator animator;



    public void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("HorizintalMove",move.x);
        animator.SetFloat("VerticalMove",move.y);
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

        if (AttackCollDawnForUnity <= 0){
            
            if(Input.GetKeyDown(KeyCode.Space))
            {   

                AttackCollDawnForUnity = AttackCollDawn;
                animator.SetTrigger("Attack");

            }
        }
        else{
            AttackCollDawnForUnity -= Time.deltaTime;
        }
    }
    public void Attack()
    {
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attack_Point.position, attack_range, enemyLayers);
        foreach(Collider2D enemy in hitEnemies){
                Debug.Log(enemy);
                enemy.GetComponent<Enemy>().TakeDamage(damage);
        }        
    }
   
    void OnDrawGizmosSelected(){
        if (attack_Point == null){
            return;
        }
        Gizmos.DrawWireSphere(attack_Point.position, attack_range);
    }
}