using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MaxHp;
    public int Hp;
    public string tagObject;
    private Animator anim;
    public Transform item;
    private Material MathBlink;
    private Material MathDefault;
    private SpriteRenderer spriteRend;



    void Start()
    {
        Hp = MaxHp;
        spriteRend = GetComponent<SpriteRenderer>();
        MathBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        MathDefault = spriteRend.material;

    }
    void Update(){
         

    }
    public void TakeDamage( int damage ){
        
        Hp -= damage;
        spriteRend.material = MathBlink;

        if (Hp <= 0){
            Die();
        }
        else{
            Invoke("ResetMaterial", .2f);
        }
    }
    void Die(){
        Destroy(gameObject);
        if (tagObject == "Enemy"){
            Instantiate(item, transform.position, transform.rotation);
            Debug.Log("Enemy Die");

        }
        else if (tagObject == "Chest")
        {
            Instantiate(item, transform.position, transform.rotation);
            Debug.Log("Chest Die");
        }
    }
    void ResetMaterial()
    {
        spriteRend.material = MathDefault;
    }
    
}
