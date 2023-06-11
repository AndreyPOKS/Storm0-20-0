using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oblako : MonoBehaviour
{
    [Header("Направление облаков")]
    public Vector2 direction;
    [Header("Скорость облаков")]
    public float speed;
    public float ForUnitySpeed;
    private float Space;
    private float HowNeedSecond;

    void Start()
    {
        Space = 300;
        ForUnitySpeed = Random.Range(1.0f, speed);
        HowNeedSecond = Space / ForUnitySpeed;
    }
    void Update()
    {
        if (HowNeedSecond <= 0){Destroy(gameObject);}
        else{HowNeedSecond = HowNeedSecond - Time.deltaTime;}
        transform.Translate(direction * ForUnitySpeed * Time.deltaTime);
    }

}
