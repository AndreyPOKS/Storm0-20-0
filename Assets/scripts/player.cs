using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [Header("Player Moving Settings")]
    public float speed;
    public Rigidbody2D rb;
    private Vector2 move;
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
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("HorizintalMove",move.x);
        animator.SetFloat("VerticalMove",move.y);
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack(1);
        }


        if (AttackCollDawnForUnity <= 0){
            
            if(Input.GetKeyDown(KeyCode.Space))
            {   

                AttackCollDawnForUnity = AttackCollDawn;
                animator.SetTrigger("Attack");
                Debug.Log("�������");

            }
        }
        else{
            AttackCollDawnForUnity -= Time.deltaTime;
        }
    }
    public void Attack(int num)
    {
<<<<<<< Updated upstream

        if (num == 1)
        {
            Collider2D[] hitChest = Physics2D.OverlapCircleAll(attack_Point.position, attack_range, ChestLayers);
            foreach (Collider2D Chest in hitChest)
            {

                Chest.GetComponent<Chest>().TakeDamage(damage);
            } 
        }
        else
        {
=======
        if (AttackCollDawnForUnity <= 0)
        {
            AttackCollDawnForUnity = AttackCollDawn;
            animator.SetTrigger("Attack");
            AttackCollDawnForUnity -= Time.deltaTime;
>>>>>>> Stashed changes
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack_Point.position, attack_range, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.tag == "EnemyRange")
                {
                    enemy.GetComponent<AIRange>().TakeDamage(damage);
                }
                else if (enemy.tag == "EnemyMelee")
                    enemy.GetComponent<AIMeele>().TakeDamage(damage);
                Debug.Log(enemy);

<<<<<<< Updated upstream
        }
=======
            }
        }
    }
   
    public void interaction()
    {
        Debug.Log("��");
        Collider2D[] Objects = Physics2D.OverlapCircleAll(attack_Point.position, attack_range, ChestLayers);
            foreach (Collider2D chest in Objects)
            {
                Debug.Log(chest);
                chest.GetComponent<Chest>().TakeDamage(damage);
                
            }

>>>>>>> Stashed changes
    }
   
    void OnDrawGizmosSelected(){
        if (attack_Point == null){
            return;
        }
        Gizmos.DrawWireSphere(attack_Point.position, attack_range);
    }
}