using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed = 20f;
    public int damage;
    public float timer;
    public Rigidbody2D rb;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;


    }

    // Update is called once per frame
    void Update()
    {   
        if (timer >=0){
            timer  -= Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else{
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D HitInfo){
        Debug.Log(HitInfo.name);
        Health health = HitInfo.gameObject.GetComponent<Health>();
        health.TakeHit(damage);
        Destroy(gameObject);
    }
}