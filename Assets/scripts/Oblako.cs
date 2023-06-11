using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oblako : MonoBehaviour
{
    [Header("Направление облаков")]
    public Vector2 direction;
    [Header("Скорость облаков")]
    public float speed;
    private float ForUnitySpeed;

    void Start()
    {
        ForUnitySpeed = Random.Range(1.0f, speed);
    }
    void Update()
    {

        transform.Translate(direction * ForUnitySpeed * Time.deltaTime);
    }
}
