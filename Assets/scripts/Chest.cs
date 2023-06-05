using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int MaxHp;
    public int Hp;
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
    void Update()
    {


    }
    public void TakeDamage(int damage)
    {
        Debug.Log("SDkaj");
        Hp -= damage;
        spriteRend.material = MathBlink;

        if (Hp <= 0)
        {
            Die();
        }
        else
        {
            Invoke("ResetMaterial", .2f);
        }
    }
    void Die()
    {
        Destroy(gameObject);
        Instantiate(item, transform.position, transform.rotation);
    }
    void ResetMaterial()
    {
        spriteRend.material = MathDefault;
    }
}
