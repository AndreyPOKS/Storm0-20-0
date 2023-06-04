using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int collisionDamage;
    public string collisionTag;


    private void OnCollisionEnter2D(Collision2D coll)
    {
        //Если тег объекта коллайдер которого столкнулся с коллайдером нашего объекта - Player
        if (coll.gameObject.tag == collisionTag)
        {
            Health health = coll.gameObject.GetComponent<Health>();
            health.TakeHit(collisionDamage);
        }
    }
}
