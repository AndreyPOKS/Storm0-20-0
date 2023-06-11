using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int MaxHp;
    public int Hp;
    public string tagObject;
    private Animator anim;
    public Image[] lives;
    public Transform item;
    private Material MathBlink;
    private Material MathDefault;
    private SpriteRenderer spriteRend;
    public Sprite FullHp;
    public Sprite EmptyHp;



    void Start()
    {
        for (int i = 0; i < lives.Length; i++)
        {

            lives[i].enabled = false;
        }
        Hp = MaxHp;
        spriteRend = GetComponent<SpriteRenderer>();
        MathBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        MathDefault = spriteRend.material;
        Invoke("ResetMaterial", .2f);


    }
    void Update(){
         

    }
    public void TakeDamage( int damage ){
        
        Hp -= damage;
        
        

        if (Hp <= 0){
            Die();
        }
        else{
            Invoke("ResetMaterial", .2f);
        }
        this.UnSetHealth(Hp);
        spriteRend.material = MathBlink;
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
    public void UnSetHealth(int Hp)
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].enabled = false;
        }
        switch (Hp)
        {
            case 60:
            case > 60:
                lives[0].sprite = FullHp;
                lives[0].enabled = true;
                break;
            case 40:
            case > 40:

                lives[1].enabled = true;
                break;
            case 20:
            case > 20:
                lives[2].enabled = true;
                break;
            case 0:
            case > 0:
                lives[3].enabled = true;
                Die();
                break;
            
        }
    }
    void ResetMaterial()
    {
        spriteRend.material = MathDefault;
    }
    
}
