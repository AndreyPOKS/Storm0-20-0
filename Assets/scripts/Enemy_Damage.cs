using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{

    public float Attack_ColDawn;
    public float Attack_ColDawn_For_Unity;
    public Transform attack_Point;
    public LayerMask HeroLayers;
    public int damage;
    public int attack_range;

    // Update is called once per frame
    void Update()
    {
        if(Attack_ColDawn_For_Unity <=0){
            Attacker();

         }
         else{
              Attack_ColDawn_For_Unity -= Time.deltaTime;
         }
    }
    void Attacker()
   {

        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attack_Point.position, attack_range, HeroLayers);
        foreach(Collider2D Player in hitEnemies){
             Debug.Log(Player);
             Player.GetComponent<Health>().TakeHit(damage);
             Attack_ColDawn_For_Unity = Attack_ColDawn;
      }
    }
   void OnDrawGizmosSelected(){
        if (attack_Point == null){
            return;
        }
        Gizmos.DrawWireSphere(attack_Point.position, attack_range);
    }
}
