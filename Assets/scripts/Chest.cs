using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int MaxHp;
    public int Hp;
    public Transform item;
    public Transform Keys;
    private float randomNumber;


    void Start()
    {
        randomNumber = Random.Range(0, 2);
        Hp = MaxHp;
    }
    void Update()
    {


    }
    public void TakeDamage(int damage)
    {
        Hp -= damage;


        if (Hp <= 0)
        {
            Die();
        }

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
