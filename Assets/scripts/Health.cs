using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    //Значение здоровья
    public int health;
    //Максимальное значение здоровья
    public int maxHealth;
    public Image[] lives; 
    private Material MathBlink;
    private Material MathDefault;
    private SpriteRenderer spriteRend;
    public Sprite FullHp;
    public Sprite EmptyHp;
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        MathBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        MathDefault = spriteRend.material;

    }

    //Функция получения урона
    public void TakeHit(int damage)
    {   

        health -= damage;
        spriteRend.material = MathBlink;
        UnSetHealth(health);
    }    
    
            
    

    //Функция прибавления здоровья
    public void SetHealth(int bonusHealth)
    {   
        health += bonusHealth;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        this.UnSetHealth(health);
    }

    public void UnSetHealth(int health)
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            Invoke("ResetMaterial", .2f);
        }
            for ( int i = 0; i < lives.Length; i++ ) {
                
                lives[i].enabled = false;
            } 
        switch (health)
        {
            case 120:
            case >100:
                lives[0].sprite = FullHp;
                lives[0].enabled = true;
                break;
            case 100:
            case >80:
               
                lives[1].enabled = true;
                break;
            case 80:
            case >60:
                lives[2].enabled = true;
                break;
            case 60:
            case >40:
                lives[3].enabled = true;
                break;
            case 40:
            case >20:
                lives[4].enabled = true;
                break;
            case 20:
            case >0:
                lives[5].enabled = true;
                break;
            default:
                lives[6].enabled = true;
                break;
        }
    }
    void ResetMaterial()
    {
        spriteRend.material = MathDefault;
    }
    
}